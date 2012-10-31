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
    public class Options
    {
        #region Constructors

        public Options()
        {
            this.Multiselect = false;
            this.Filter = null;
            this.InitialDirectory = null;
            this.Title = null;
        }

        #endregion Constructors

        #region Properties

        public static Options Default
        {
            get { return new Options(); }
        }

        public string Filter
        {
            get; set;
        }

        public string InitialDirectory
        {
            get; set;
        }

        public bool Multiselect
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        #endregion Properties
    }
}