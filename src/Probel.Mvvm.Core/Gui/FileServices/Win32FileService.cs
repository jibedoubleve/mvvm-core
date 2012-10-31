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

namespace Probel.Mvvm.Gui.FileServices
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Implements the FileService with Microsoft.Win32 
    /// </summary>
    public class Win32FileService : IFileService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32FileService"/> class.
        /// </summary>
        internal Win32FileService()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SelectDirectory(Action<string> action)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            var dr = folderBrowserDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                action(folderBrowserDialog.SelectedPath);
            }
            else { return; }
        }

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SelectFile(Action<string> action)
        {
            this.SelectFile(action, Options.Default);
        }

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SelectFile(Action<string> action, Options options)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = options.Filter;
            openFileDialog.Multiselect = options.Multiselect;
            openFileDialog.InitialDirectory = options.InitialDirectory;
            openFileDialog.Title = options.Title;

            bool? flag = openFileDialog.ShowDialog();

            if (flag.HasValue && flag.Value)
            {
                action(openFileDialog.FileName);
            }
            else { return; }
        }

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SelectFileToSave(Action<string> action)
        {
            this.SelectFileToSave(action, Options.Default);
        }

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SelectFileToSave(Action<string> action, Options options)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = options.Filter;
            saveFileDialog.InitialDirectory = options.InitialDirectory;
            saveFileDialog.Title = options.Title;

            bool? flag = saveFileDialog.ShowDialog();
            if (flag.HasValue && flag.Value)
            {
                action(saveFileDialog.FileName);
            }
            else { return; }
        }

        #endregion Methods
    }
}