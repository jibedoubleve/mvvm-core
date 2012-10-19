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
namespace Probel.Mvvm.Gui.FileServices
{
    /// <summary>
    /// Provides the implementation of the FileServices
    /// </summary>
    public static class FileServiceFactory
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="IFileService"/> implemented with Microsoft.Win32.
        /// </summary>
        public static IFileService Win32
        {
            get { return new Win32FileService(); }
        }

        #endregion Properties
    }
}