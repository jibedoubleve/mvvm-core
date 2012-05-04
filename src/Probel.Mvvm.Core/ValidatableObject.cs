namespace Probel.Mvvm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class ValidatableObject : ObservableObject, IDataErrorInfo
    {
        #region Constructors

        public ValidatableObject()
        {
            this.Validators = new Dictionary<string, Rule>();
        }

        #endregion Constructors

        #region Properties

        public string Error
        {
            get { return null; }
        }

        private Dictionary<string, Rule> Validators
        {
            get;
            set;
        }

        #endregion Properties

        #region Indexers

        public string this[string columnName]
        {
            get
            {
                if (this.Validators.ContainsKey(columnName))
                {
                    var validator = this.Validators[columnName];

                    return (validator.Condition())
                        ? null
                        : validator.Error;
                }
                else { return null; }
            }
        }

        #endregion Indexers

        #region Methods

        public void AddRule<TProperty>(Expression<Func<TProperty>> property, string error, Func<bool> validation)
        {
            var key = property.GetMemberInfo().Name;
            if (!this.Validators.ContainsKey(key))
            {
                this.Validators.Add(key, new Rule(validation, error));
            }
            else
            {
                this.Validators.Remove(key);
                this.Validators.Add(key, new Rule(validation, error));
            }
        }

        public string Validate(string propertyName)
        {
            if (this.Validators.ContainsKey(propertyName))
            {
                return this.Validators[propertyName].Condition()
                    ? null
                    : this.Validators[propertyName].Error;
            }
            else { return null; }
        }

        #endregion Methods
    }
}