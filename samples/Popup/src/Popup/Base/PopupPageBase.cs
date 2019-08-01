using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI.Plugins.Popup;
using Xamarin.Forms;

namespace Popup
{
    public abstract class PopupPageBase<T> : ReactivePopupPage<T>
        where T : class
    {
        protected PopupPageBase()
        {
            SystemPaddingSides = Rg.Plugins.Popup.Enums.PaddingSide.All;
        }
    }
}
