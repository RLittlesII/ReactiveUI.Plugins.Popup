using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Plugins.Popup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : PopupPageBase<ModalViewModel>
    {
        public ModalPage()
        {
            InitializeComponent();
            ViewModel = new ModalViewModel();

            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel, x => x.PopModal, x => x.PopModalButton);
                this.WhenAnyObservable(x => x.ViewModel.PopModal).Subscribe(_ => Navigation.PopPopup().Subscribe());
            });
        }
    }
}