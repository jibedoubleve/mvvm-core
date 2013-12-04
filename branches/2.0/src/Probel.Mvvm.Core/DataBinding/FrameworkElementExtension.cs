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
namespace Probel.Mvvm.DataBinding
{
    using System;
    using System.Windows;

    using Probel.Mvvm.Gui;

    /// <summary>
    /// Add extension methods to manage the Views and the ViewModels
    /// </summary>
    public static class FrameworkElementExtension
    {
        #region Methods

        /// <summary>
        /// Returns the ViewModel as it is configured in the specified View
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="view">The view.</param>
        /// <returns>The specified ViewModel</returns>
        /// <exception cref="NullDataContextException">Thrown of the DataContext of the specified view is not set</exception>
        /// <exception cref="UnexpectedDataContextException">Thrown if the type of the DataContext of the view is not of the expected type</exception>
        public static TViewModel As<TViewModel>(this FrameworkElement view)
            where TViewModel : class
        {
            if (view.DataContext == null) { throw new NullDataContextException(); }
            else
            {
                try { return (TViewModel)view.DataContext; }
                catch (InvalidCastException ex)
                {
                    throw new UnexpectedDataContextException(typeof(TViewModel), view.DataContext.GetType(), ex); ;
                }
                catch { throw; }
            }
        }

        #endregion Methods
    }
}