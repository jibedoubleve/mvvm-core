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
    using System.Windows;
    using Probel.Mvvm.Gui.MessageBoxes;

    /// <summary>
    /// Provides all the feature for window management
    /// </summary>
    public static class ViewService
    {
        #region Fields

        private static readonly WindowManager WindowManager = new WindowManager();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the window manager.
        /// </summary>
        public static IWindowManager Manager
        {
            get { return WindowManager; }
        }

        /// <summary>
        /// Gets or sets the root window. That's the parent window of all tool boxes
        /// </summary>
        /// <value>
        /// The root window.
        /// </value>
        public static Window RootWindow
        {
            get { return WindowManager.RootWindow; }
        }

        /// <summary>
        /// Gets the configured <see cref="IMessageBox"/>. If no message box is configured, it returns the default implementation
        /// which is using the System.Window.MessageBox
        /// </summary>
        public static IMessageBox MessageBox
        {
            get
            {
                return (WindowManager.MessageBox == null)
                    ? new WindowsMessageBox()
                    : WindowManager.MessageBox;
            }
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Configures the specifie the ViewService.
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        public static void Configure(Action<IWindowConfigurator> configurator)
        {
            configurator(WindowManager);
        }

        #endregion Methods
    }
}