using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using Rg.Plugins.Popup.Extensions;
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
        public static IObservable<Unit> PopAllPopup(this INavigation navigation, bool animate = true) =>
            Observable.FromAsync(async x => await navigation.PopAllPopupAsync(animate).ConfigureAwait(false));

        /// <summary>
        /// Pops the <see cref="PopupPage"/> from navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PopPopup(this INavigation navigation, bool animate = true) =>
            Observable.FromAsync(async x => await navigation.PopPopupAsync(animate).ConfigureAwait(false));

        /// <summary>
        /// Pushes the <see cref="PopupPage" /> onto the navigation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="navigation">The navigation.</param>
        /// <param name="popupPage">The popup page.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PushPopup<T>(this INavigation navigation, T popupPage, bool animate = true)
            where T : PopupPage => Observable.FromAsync(async x => await navigation.PushPopupAsync(popupPage, animate).ConfigureAwait(false));

        /// <summary>
        /// Removes the <see cref="PopupPage" /> from the navigation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="navigation">The navigation.</param>
        /// <param name="popupPage">The popup page.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> RemovePopupPage<T>(this INavigation navigation, T popupPage, bool animate = true)
            where T : PopupPage => Observable.FromAsync(async x => await navigation.RemovePopupPageAsync(popupPage, animate).ConfigureAwait(false));
    }
}
