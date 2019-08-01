using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;

namespace Popup
{
    public class AppBootstrapper
    {
        public AppBootstrapper()
        {
            RegisterViews(Locator.CurrentMutable);
            RegisterViewModels(Locator.CurrentMutable);
            RegisterServices(Locator.CurrentMutable);
        }

        public RoutedViewHost CreateViewHost()
        {
            return new RoutedViewHost();
        }

        private void RegisterServices(IMutableDependencyResolver registrar)
        {
        }

        private void RegisterViews(IMutableDependencyResolver registrar)
        {
            registrar.RegisterLazySingleton(() => new Screen(), typeof(IScreen));
            registrar.Register(() => new StartPage(), typeof(IViewFor<StartViewModel>));
            registrar.Register(() => new ModalPage(), typeof(IViewFor<ModalViewModel>));
        }

        private void RegisterViewModels(IMutableDependencyResolver registrar)
        {
        }
    }
}