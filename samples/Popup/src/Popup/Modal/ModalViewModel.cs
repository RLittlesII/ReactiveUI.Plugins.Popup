using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace Popup
{
    public class ModalViewModel : ReactiveObject
    {
        public ModalViewModel() { PopModal = ReactiveCommand.Create(() => { }); }

        public ReactiveCommand<Unit, Unit> PopModal { get; set; }
    }
}
