using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace Popup
{
    internal class Screen : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public Screen()
        {
            Router = new RoutingState();

            Router
                .NavigateAndReset
                .Execute(new StartViewModel())
                .Subscribe();
        }

        public Page PresentDefaultView() => new RoutedViewHost();
    }
}
