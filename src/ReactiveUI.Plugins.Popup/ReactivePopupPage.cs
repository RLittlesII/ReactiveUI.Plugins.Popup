using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Mopups.Enums;
using Mopups.Pages;
using ReactiveUI;

namespace RxUI.Plugins.Popup
{
    /// <summary>
    /// Base Popup page for that implements <see cref="IViewFor"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The view model type.</typeparam>
    public abstract class ReactivePopupPage<TViewModel> : ReactivePopupPage, IViewFor<TViewModel>
        where TViewModel : class
    {
        /// <summary>
        /// The view model property.
        /// </summary>
        public new static readonly BindableProperty ViewModelProperty = BindableProperty.Create(
            nameof(ViewModel),
            typeof(TViewModel),
            typeof(IViewFor<TViewModel>),
            (object)null,
            BindingMode.OneWay,
            (BindableProperty.ValidateValueDelegate)null,
            new BindableProperty.BindingPropertyChangedDelegate(OnViewModelChanged),
            (BindableProperty.BindingPropertyChangingDelegate)null,
            (BindableProperty.CoerceValueDelegate)null,
            (BindableProperty.CreateDefaultValueDelegate)null);

        /// <summary>
        /// Gets or sets the ViewModel corresponding to this specific View.
        /// This should be a BindableProperty if you're using XAML.
        /// </summary>
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TViewModel)value;
        }

        /// <summary>
        /// Gets or sets the ViewModel to display.
        /// </summary>
        public new TViewModel ViewModel
        {
            get => (TViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        /// <summary>
        /// Gets the control binding disposable.
        /// </summary>
        protected new CompositeDisposable ControlBindings { get; } = new CompositeDisposable();

        /// <inheritdoc/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            ViewModel = BindingContext as TViewModel;
        }

        private static void OnViewModelChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            bindableObject.BindingContext = newValue;
        }
    }

    /// <summary>
    /// Base Popup page for that implements <see cref="IViewFor"/>.
    /// </summary>
    public abstract class ReactivePopupPage : PopupPage, IViewFor
    {
        /// <summary>
        /// The view model property.
        /// </summary>
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(
            nameof(ViewModel),
            typeof(object),
            typeof(IViewFor<object>),
            (object)null,
            BindingMode.OneWay,
            (BindableProperty.ValidateValueDelegate)null,
            new BindableProperty.BindingPropertyChangedDelegate(OnViewModelChanged),
            (BindableProperty.BindingPropertyChangingDelegate)null,
            (BindableProperty.CoerceValueDelegate)null,
            (BindableProperty.CreateDefaultValueDelegate)null);

        /// <summary>
        /// Gets or sets the background click observable signal.
        /// </summary>
        /// <value>The background click.</value>
        public IObservable<Unit> BackgroundClick { get; protected set; }

        /// <summary>
        /// Gets or sets the ViewModel to display.
        /// </summary>
        public object ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        /// <summary>
        /// Gets the control binding disposable.
        /// </summary>
        protected CompositeDisposable ControlBindings { get; } = new CompositeDisposable();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactivePopupPage{TViewModel}"/> class.
        /// </summary>
        protected ReactivePopupPage()
        {
            BackgroundClick =
                Observable.FromEvent<EventHandler, Unit>(
                        handler =>
                        {
                            void EventHandler(object sender, EventArgs args) => handler(Unit.Default);
                            return EventHandler;
                        },
                        x => BackgroundClicked += x,
                        x => BackgroundClicked -= x)
                    .Select(_ => Unit.Default);
        }

        /// <inheritdoc/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            ViewModel = BindingContext;
        }

        private static void OnViewModelChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            bindableObject.BindingContext = newValue;
        }
    }
}
