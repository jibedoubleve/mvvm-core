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

    /// <summary>
    /// To be a Window Manager, a class should implements these basic features
    /// </summary>
    public interface IWindowManager
    {
        #region Methods

        /// <summary>
        /// Resets the repository.
        /// </summary>
        void Reset();

        /// <summary>
        /// Shows the Window linkned to this ViewModel as a model window.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        void Show<TViewModel>();

        /// <summary>
        /// Shows the window linked to the TViewModel type as a modal box.
        /// If a OnShow action is set, it'll be executed as well.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="beforeShowing">Represent the action to execute before showing the view.</param>
        void Show<TViewModel>(Action<TViewModel> beforeShowing);

        /// <summary>
        /// Shows the Window linkned to this ViewModel as a dialog window.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>();

        /// <summary>
        /// Shows window linked to the TViewModel type as a dialog box and execute the specified action.
        /// If a OnShow action is set, it'll be executed as well.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="beforeShowing">Represent the action to execute before showing the view.</param>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>(Action<TViewModel> beforeShowing);

        #endregion Methods
    }
}