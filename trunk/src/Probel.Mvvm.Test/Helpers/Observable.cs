namespace Probel.Mvvm.Test.Helpers
{
    using Probel.Mvvm.DataBinding;

    public class Observable : ObservableObject
    {
        #region Fields

        public const string PropName_TriggerOnLambda = "TriggerOnLambda";
        public const string PropName_TriggerOnString = "TriggerOnString";

        private string failure = string.Empty;
        private string triggerOnLambda = string.Empty;
        private string triggerOnString = string.Empty;

        #endregion Fields

        #region Properties

        public string TriggerOnLambda
        {
            get { return this.triggerOnLambda; }
            set
            {
                this.triggerOnLambda = value;
                this.OnPropertyChanged(() => this.TriggerOnLambda);
            }
        }

        #endregion Properties
    }
}