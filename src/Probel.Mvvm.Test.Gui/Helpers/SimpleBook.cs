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
namespace Probel.Mvvm.Test.Gui.Helpers
{
    using System;

    using Probel.Mvvm.DataBinding;

    public class SimpleBookDto : ObservableObject
    {
        #region Fields

        private int pages = 0;
        private string title = string.Empty;

        #endregion Fields

        #region Constructors

        public SimpleBookDto()
        {
        }

        #endregion Constructors

        #region Properties

        public int Pages
        {
            get { return this.pages; }
            set
            {
                this.pages = value;
                this.OnPropertyChanged(() => this.Pages);
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged(() => this.Title);
            }
        }

        #endregion Properties
    }
}