namespace Probel.Mvvm
{
    using System;

    internal class Rule
    {
        #region Constructors

        public Rule(Func<bool> condition, string error)
        {
            this.Condition = condition;
            this.Error = error;
        }

        #endregion Constructors

        #region Properties

        public Func<bool> Condition
        {
            get; private set;
        }

        public string Error
        {
            get; private set;
        }

        #endregion Properties
    }
}