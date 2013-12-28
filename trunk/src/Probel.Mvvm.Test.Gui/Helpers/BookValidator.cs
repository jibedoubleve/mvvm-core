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
    using Probel.Mvvm.Validation;
    using System;


    public class BookValidator : IValidator
    {
        #region Properties

        public string Error
        {
            get { return "This is not a valid book"; }
        }

        #endregion Properties

        #region Methods

        public void SetValidationLogic(ValidatableObject item)
        {
            var book = item as BookDto;

            if (book == null) throw new ArgumentException("item");

            book.AddValidationRule(() => book.Pages
                , () => book.Pages > 10
                , "A book should have more than 10 pages");

            book.AddValidationRule(() => book.Title
                , () => book.Title.Length > 5
                , "A title should be longer than 5 char");
        }

        #endregion Methods
    }
}