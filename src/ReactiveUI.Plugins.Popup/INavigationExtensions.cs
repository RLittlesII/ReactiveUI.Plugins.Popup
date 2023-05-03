using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;
using Mopup.Pages;
using Mopup.Services;

namespace RxUI.Plugins.Popup
{
    public static class INavigationExtensions
    {
        /// <summary>
        /// Pops all <see cref="PopupPage"/> from the navigation.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PopAllPopup(this INavigation navigation, bool animate = true) =>
            Observable.FromAsync(async _ => await MopupService.Instance.PopAllAsync(animate).ConfigureAwait(false));



        /// <summary>
                /// Pops the <see cref="PopupPage"/> from navigation.
                /// </summary>
                /// <param name="navigation">The navigation.</param>
                /// <param name="animate">if set to <c>true</c> [animate].</param>
                /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PopPopup(this INavigation navigation, bool animate = true) =>
            Observable.FromAsync(async _ => await MopupService.Instance.PopAsync(animate).ConfigureAwait(false));



        /// <summary>
                /// Pushes the <see cref="PopupPage" /> onto the navigation.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="navigation">The navigation.</param>
                /// <param name="popupPage">The popup page.</param>
                /// <param name="animate">if set to <c>true</c> [animate].</param>
                /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> PushPopup<T>(this INavigation navigation, T popupPage, bool animate = true)
            where T : PopupPage => Observable.FromAsync(async _ => await MopupService.Instance.PushAsync(popupPage, animate).ConfigureAwait(false));



        /// <summary>
                /// Removes the <see cref="PopupPage" /> from the navigation.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="navigation">The navigation.</param>
                /// <param name="popupPage">The popup page.</param>
                /// <param name="animate">if set to <c>true</c> [animate].</param>
                /// <returns>An observable sequence to signal completion.</returns>
        public static IObservable<Unit> RemovePopupPage<T>(this INavigation navigation, T popupPage, bool animate = true)
            where T : PopupPage => Observable.FromAsync(async _ => await MopupService.Instance.RemovePageAsync(popupPage, animate).ConfigureAwait(false));
    }
}
