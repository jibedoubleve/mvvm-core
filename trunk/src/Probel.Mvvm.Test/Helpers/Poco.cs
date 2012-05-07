namespace Probel.Mvvm.Test.Helpers
{
    using Probel.Mvvm.DataBinding;

    public class Poco : ObservableObject
    {
        #region Fields

        public const string PropName_TriggerOnLambda = "TriggerOnLambda";
        public const string PropName_TriggerOnString = "TriggerOnString";

        private string failure = string.Empty;
        private string triggerOnLambda = string.Empty;
        private string triggerOnString = string.Empty;

        #endregion Fields

        #region Properties

        public string Failure
        {
            get { return this.failure; }
            set
            {
                this.failure = value;
                this.OnPropertyChanged("It will fail");
            }
        }

        public string TriggerOnLambda
        {
            get { return this.triggerOnLambda; }
            set
            {
                this.triggerOnLambda = value;
                this.OnPropertyChanged(() => this.TriggerOnLambda);
            }
        }

        public string TriggerOnString
        {
            get { return this.triggerOnString; }
            set
            {
                this.triggerOnString = value;
                this.OnPropertyChanged(Poco.PropName_TriggerOnString);
            }
        }

        #endregion Properties
    }
}