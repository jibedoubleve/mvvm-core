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

    using Probel.Mvvm.Gui.FileServices;

    /// <summary>
    /// Provides an generic way to select file or directories
    /// </summary>
    public interface IFileGui
    {
        #region Methods

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectDirectory(Action<string> action);

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFile(Action<string> action);

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFile(Action<string> action, Options options);

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFileToSave(Action<string> action, Options options);

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFileToSave(Action<string> action);

        #endregion Methods
    }
}