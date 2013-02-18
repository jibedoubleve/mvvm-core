#region Header

/*
    This file is part of Mvvm-core.

    Mvvm-core is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Mvvm-core is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Mvvm-core.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion Header

namespace Probel.Mvvm.Gui
{
    using System;
    using System.Globalization;
    using System.Windows;

    using Probel.Mvvm.Gui.MessageBoxes;

    /// <summary>
    /// Used to configure the window service
    /// </summary>
    public interface IWindowConfigurator
    {
        #region Properties

        /// <summary>
        /// Each time the Show and ShowDialog methods are called, the current thread's CurrentCulture will be set with this <see cref="CultureInfo"/>       
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        CultureInfo Culture
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is under test.
        /// That's, if this instance is under test, the View won't be showed when 
        /// using the methods Show() or ShowDialog()
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is under test; otherwise, <c>false</c>.
        /// </value>
        bool IsUnderTest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the abstraction for the message box.
        /// </summary>
        /// <value>
        /// The message box implementation.
        /// </value>
        IMessageBox MessageBox
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the root window. That's the parent window of all tool boxes
        /// </summary>
        /// <value>
        /// The root window.
        /// </value>
        Window RootWindow
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to throws an exception if a window is already binded.
        /// </summary>
        /// <value><c>true</c> if an exception should be thrown if the window is already binded; otherwise, <c>false</c>.</value>
        bool ThrowsIfNotBinded
        {
            get;
            set;
        }

        /// <summary>
        /// Each time the Show and ShowDialog methods are called, the current thread's CurrentUICulture will be set with this <see cref="CultureInfo"/>       
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        CultureInfo UICulture
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Binds the specified lambda to the specified TViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="ctor">The lambda that will create a fresh instance of the Window.</param>
        IConfigurationExpression<TViewModel> Bind<TViewModel>(Func<Window> ctor);

        /// <summary>
        /// Binds the TView type to the TViewModel.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        IConfigurationExpression<TViewModel> Bind<TView, TViewModel>()
            where TView : Window, new();

        /// <summary>
        /// Binds the specified ctor to the specified type. It means that when user ask to show a window
        /// this specified lambda will returns a fresh instance of a window
        /// </summary>
        /// <param name="ctor">The lambda that should create a fresh instance of a window.</param>
        /// <param name="type">The type linked to the lambda.</param>        
        void Bind(Func<Window> ctor, Type type);

        /// <summary>
        /// Resets the whole repository.
        /// </summary>
        void Reset();

        #endregion Methods
    }
}