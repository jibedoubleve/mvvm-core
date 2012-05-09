namespace Probel.Mvvm.Test.Helpers
{
    using System;
    using Probel.Mvvm.DataBinding;

    public class UserDto : BaseDto<int>
    {
        #region Fields

        private DateTime birthdate;
        private int height;
        private string name;

        #endregion Fields

        #region Constructors

        public UserDto()
        {
            this.Ignore(() => this.Birthdate);
        }

        #endregion Constructors

        #region Properties

        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set
            {
                this.birthdate = value;
                this.OnPropertyChanged(() => this.Birthdate);
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                this.OnPropertyChanged(() => this.Height);
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnPropertyChanged(() => this.Name);
            }
        }

        #endregion Properties
    }
}