using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using RxUI.Plugins.Popup;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ReactiveContentPage<StartViewModel>
    {
        public StartPage()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel, x => x.PushModal, x => x.PushModalButton)
                    .DisposeWith(disposables);

                this.WhenAnyObservable(x => x.ViewModel.PushModal)
                    .Subscribe(_ => { Navigation.PushPopup(new ModalPage()).Subscribe(); });
            });
        }
    }
}