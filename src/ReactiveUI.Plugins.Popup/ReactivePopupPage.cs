using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ReactiveUI.Plugins.Popup
{
    /// <summary>
    /// Base Popup page for that implements <see cref="IViewFor"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The view model type.</typeparam>
    public abstract class ReactivePopupPage<TViewModel> : PopupPage, IViewFor<TViewModel>
        where TViewModel : class
    {
        /// <summary>
        /// The view model property.
        /// </summary>
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(
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
        /// Initializes a new instance of the <see cref="ReactivePopupPage{TViewModel}"/> class.
        /// </summary>
        protected ReactivePopupPage()
        {
            BackgroundClick =
                Observable
                    .FromEventPattern(x => BackgroundClicked += x, x => BackgroundClicked -= x)
                    .Select(x => Unit.Default);
        }

        /// <summary>
        /// Gets or sets the background click observable signal.
        /// </summary>
        /// <value>The background click.</value>
        public IObservable<Unit> BackgroundClick { get; protected set; }

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
        public TViewModel ViewModel
        {
            get => (TViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, (object)value);
        }

        /// <summary>
        /// Gets the control binding disposable.
        /// </summary>
        protected CompositeDisposable ControlBindings { get; } = new CompositeDisposable();

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
}
