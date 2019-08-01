using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using ReactiveUI;

namespace Popup
{
    public class StartViewModel : ViewModelBase
    {
        public override string UrlPathSegment => "Start";

        public StartViewModel()
        {
            PushModal = ReactiveCommand.Create(() => { });
        }

        public ReactiveCommand<Unit, Unit> PushModal { get; set; }
    }
}
