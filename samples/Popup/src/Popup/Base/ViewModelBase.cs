using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace Popup
{
    public abstract class ViewModelBase : ReactiveObject, IRoutableViewModel
    {
        public abstract string UrlPathSegment { get; }

        public IScreen HostScreen => Locator.Current.GetService<IScreen>();
    }
}
