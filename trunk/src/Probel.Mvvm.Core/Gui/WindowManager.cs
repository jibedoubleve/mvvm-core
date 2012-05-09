﻿/*
    This file is part of Probel.Mvvm.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.Mvvm.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// This manager will keep links between View and ViewModel to help user to open new windows
    /// just by knowing the type of the ViewModel.
    /// </summary>
    public class WindowManager : IWindowManager
    {
        #region Fields

        private static Dictionary<Type, Func<Window>> bindingCollection = new Dictionary<Type, Func<Window>>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowManager"/> class.
        /// </summary>
        public WindowManager()
        {
            this.ThrowsIfNotBinded = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowManager"/> class.
        /// </summary>
        /// <param name="throwsIfNotBinded">if set to <c>true</c> [throws if not binded].</param>
        public WindowManager(bool throwsIfNotBinded)
        {
            this.ThrowsIfNotBinded = throwsIfNotBinded;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to throws an exception if a window is already binded.
        /// </summary>
        /// <value><c>true</c> if an exception should be thrown if the window is already binded; otherwise, <c>false</c>.</value>
        public bool ThrowsIfNotBinded
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Binds the specified ctor to the specified type. It means that when user ask to show a window
        /// this specified lambda will returns a fresh instance of a window
        /// </summary>
        /// <param name="ctor">The lambda that should create a fresh instance of a window.</param>
        /// <param name="type">The type linked to the lambda.</param>
        public void Bind(Func<Window> ctor, Type type)
        {
            if (bindingCollection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            bindingCollection.Add(type, ctor);
        }

        /// <summary>
        /// Binds the specified lambda to the specified TViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="ctor">The lambda that will create a fresh instance of the Window.</param>
        public void Bind<TViewModel>(Func<Window> ctor)
        {
            var type = typeof(TViewModel);

            if (bindingCollection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            bindingCollection.Add(type, ctor);
        }

        /// <summary>
        /// Binds the TView type to the TViewModel.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Bind<TView, TViewModel>()
            where TView : Window, new()
        {
            this.Bind<TViewModel>(() => new TView());
        }

        /// <summary>
        /// Resets the whole repository.
        /// </summary>
        public void Reset()
        {
            bindingCollection.Clear();
        }

        /// <summary>
        /// Shows the window linked to the TViewModel type as a modal box.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Show<TViewModel>()
        {
            var type = typeof(TViewModel);

            if (!bindingCollection.ContainsKey(type))
            {
                if (this.ThrowsIfNotBinded) { throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type)); }
                else { return; }
            }

            var win = bindingCollection[typeof(TViewModel)]();
            if (win != null) win.Show();
        }

        /// <summary>
        /// Shows window linked to the TViewModel type as a dialog box.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        public bool? ShowDialog<TViewModel>()
        {
            var type = typeof(TViewModel);

            if (!bindingCollection.ContainsKey(type))
            {
                if (this.ThrowsIfNotBinded) { throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type)); }
                else { return null; }
            }

            var win = bindingCollection[type]();
            if (win != null) return win.ShowDialog();
            else return null;
        }

        #endregion Methods
    }
}