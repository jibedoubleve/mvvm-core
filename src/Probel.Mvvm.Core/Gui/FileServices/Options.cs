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
    /// Options to configure a FileService item
    /// </summary>
    public class Options
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        public Options()
        {
            this.Multiselect = false;
            this.Filter = null;
            this.InitialDirectory = null;
            this.Title = null;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the default options.
        /// </summary>
        public static Options Default
        {
            get { return new Options(); }
        }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the initial directory.
        /// </summary>
        /// <value>
        /// The initial directory.
        /// </value>
        public string InitialDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether multiple file can be selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if multiselect; otherwise, <c>false</c>.
        /// </value>
        public bool Multiselect
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get;
            set;
        }

        #endregion Properties
    }
}