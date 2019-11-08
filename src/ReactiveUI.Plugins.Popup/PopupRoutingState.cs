using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Text;
using ReactiveUI;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;

namespace RxUI.Plugins.Popup
{
    public class PopupRoutingState : RoutingState
    {
        private IPopupNavigation _popupNavigation;

        [DataMember]
        private readonly ObservableCollection<IRoutableViewModel> _popupNavigationStack;

        public PopupRoutingState()
        {
            _popupNavigation = PopupNavigation.Instance;

            var navigateScheduler = RxApp.MainThreadScheduler; // TODO: Allow user to set scheduler.

            var countAsBehavior = Observable.Concat(Observable.Defer(() => Observable.Return(NavigationStack.Count)),NavigationChanged.CountChanged().Select(_ => NavigationStack.Count));

            NavigatePopup = ReactiveCommand.CreateFromObservable<IRoutableViewModel, IRoutableViewModel>(
                vm =>
                {
                    if (vm == null)
                    {
                        throw new Exception($"Navigate must be called on an {nameof(IRoutableViewModel)}");
                    }

                    _popupNavigationStack.Add(vm);
                    return Observable.Return(vm);
                },
                outputScheduler: navigateScheduler);

            NavigatePopupBack = ReactiveCommand.CreateFromObservable<Unit, Unit>(
                _ =>
                {
                    _popupNavigationStack.RemoveAt(PopupNavigationStack.Count - 1);
                    return Observable.Return(Unit.Default);
                },
                countAsBehavior.Select(x => x > 1),
                navigateScheduler);
        }

        /// <summary>
        /// Gets the current navigation stack, the last element in the
        /// collection being the currently visible ViewModel.
        /// </summary>
        [IgnoreDataMember]
        public ObservableCollection<IRoutableViewModel> PopupNavigationStack => _popupNavigationStack;

        /// <summary>
        /// Gets or sets a command that navigates to the a new element in the stack - the Execute parameter
        /// must be a ViewModel that implements IRoutableViewModel.
        /// </summary>
        [IgnoreDataMember]
        public ReactiveCommand<IRoutableViewModel, IRoutableViewModel> NavigatePopup { get; protected set; }

        /// <summary>
        /// Gets or sets a command which will navigate back to the previous element in the stack.
        /// </summary>
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> NavigatePopupBack { get; protected set; }

    }
}
