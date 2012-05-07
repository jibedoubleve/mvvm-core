/*
    This file is part of Probel.Mvvm.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.Mvvm.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Probel.Mvvm.DataBinding;

    /// <summary>
    /// Every objects that derive from this class will have the features to validates its properties
    /// and be used with WPF technology because it implements the IDataErrorInfo interface.
    /// </summary>
    public class ValidatableObject : ObservableObject, IDataErrorInfo
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatableObject"/> class.
        /// </summary>
        public ValidatableObject()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatableObject"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ValidatableObject(string error)
        {
            this.Validators = new Dictionary<string, ValidationRule>();
            this.Error = error;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get;
            private set;
        }

        private Dictionary<string, ValidationRule> Validators
        {
            get;
            set;
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Adds a new valudation rule.
        /// The validation returns <c>True</c> when the property tested is valid; otherwise <c>False</c>
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property to validate.</param>
        /// <param name="error">The error to display if the property is not valid.</param>
        /// <param name="validation">The validation condition. This returns <c>True</c> 
        /// if the property is valid; otherwise <c>False</c></param>
        /// <exception cref="ExistingRuleException">If a validation is already set for the specified property</exception>
        public void AddRule<TProperty>(Expression<Func<TProperty>> property, string error, Func<bool> validation)
        {
            var key = property.GetMemberInfo().Name;

            if (this.Validators.ContainsKey(key))
            {
                throw new ExistingRuleException();
            }
            else
            {
                this.Validators.Add(key, new ValidationRule(validation, error));
            }
        }

        /// <summary>
        /// Validates the specified property.
        /// </summary>
        /// <param name="property">Name of the property.</param>
        /// <returns>The error message if the validation rule failed; otherwise <c>Null</c></returns>
        public string Validate(string property)
        {
            if (this.Validators.ContainsKey(property))
            {
                return this.Validators[property].Condition()
                    ? null
                    : this.Validators[property].Error;
            }
            else { return null; }
        }

        #endregion Methods
    }
}