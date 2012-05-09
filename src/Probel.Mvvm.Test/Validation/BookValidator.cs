namespace Probel.Mvvm.Test.Validation
{
    using System;

    using Probel.Mvvm.Test.Helpers;
    using Probel.Mvvm.Validation;

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