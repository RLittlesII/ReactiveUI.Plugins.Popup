using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ReactiveUI.Plugins.Popup
{
    /// <summary>
    /// Extension methods for the <see cref="INavigation"/> service to interact with <see cref="PopupPage"/> objects.
    /// </summary>
    public static class INavigationExtensions
    {
        /// <summary>
        /// Pops all <see cref="PopupPage"/> from the navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PopAllPopup(this INavigation navigation, bool animate) =>
            Observable.FromAsync(async x => await navigation.PopAllPopup(animate));

        /// <summary>
        /// Pops the <see cref="PopupPage"/> from navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PopPopup(this INavigation navigation, bool animate) =>
            Observable.FromAsync(async x => await navigation.PopPopup(animate));

        /// <summary>
        /// Pushes the <see cref="PopupPage"/> onto the navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PushPopup(this INavigation navigation, bool animate) =>
            Observable.FromAsync(async x => await navigation.PushPopup(animate));

        /// <summary>
        /// Removes the <see cref="PopupPage"/> from the navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> RemovePopupPage(this INavigation navigation, bool animate) =>
            Observable.FromAsync(async x => await navigation.RemovePopupPage(animate));
    }
}
