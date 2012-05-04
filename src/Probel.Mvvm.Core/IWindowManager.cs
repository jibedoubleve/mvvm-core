/*
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
namespace Probel.Mvvm
{
    /// <summary>
    /// To  be a Window Manager, a class should implements these basic features
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
        /// Shows the Window linkned to this ViewModel as a dialog window.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>();

        #endregion Methods
    }
}