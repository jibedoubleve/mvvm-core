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
    /// This interface is used to make WindowManager fluent.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface IConfigurationExpression<TViewModel>
    {
        #region Methods

        /// <summary>
        /// Hook a handler that will be executed when the View will be closing
        /// </summary>
        /// <param name="handler">The action.</param>
        /// <returns></returns>
        IConfigurationExpression<TViewModel> OnClosing(Action<TViewModel> handler);
        /// <summary>
        /// Hook a handler that will be executed when the View will be closing
        /// </summary>
        /// <param name="handler">The action.</param>
        /// <returns></returns>
        IConfigurationExpression<TViewModel> OnClosing(Action handler);

        /// <summary>
        /// Hook a handler that will be executed when the View will be showed
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <returns></returns>
        IConfigurationExpression<TViewModel> OnShow(Action<TViewModel> handler);
        /// <summary>
        /// Hook a handler that will be executed when the View will be showed
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <returns></returns>
        IConfigurationExpression<TViewModel> OnShow(Action handler);

        #endregion Methods
    }
}