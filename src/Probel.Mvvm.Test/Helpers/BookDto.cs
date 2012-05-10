namespace Probel.Mvvm.Test.Helpers
{
    using Probel.Mvvm.Test.Validation;

    public class BookDto : BaseDto<long>
    {
        #region Fields

        private int pages = 0;
        private string title = string.Empty;

        #endregion Fields

        #region Constructors

        public BookDto()
            : base(new BookValidator())
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