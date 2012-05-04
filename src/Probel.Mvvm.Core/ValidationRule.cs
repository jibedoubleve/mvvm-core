namespace Probel.Mvvm
{
    using System;

    /// <summary>
    /// Represents a validaton rule to check whether a property's value is valid or not
    /// </summary>
    internal class ValidationRule
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRule"/> class.
        /// </summary>
        /// <param name="condition">The condition to succeed to have a valid property's value.</param>
        /// <param name="error">The error.</param>
        public ValidationRule(Func<bool> condition, string error)
        {
            this.Condition = condition;
            this.Error = error;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the condition to succeed to have a valid property's value.
        /// </summary>
        /// <value>The condition.</value>
        public Func<bool> Condition
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the error message to display if the condition failed.
        /// If the value is <c>Null</c>, it means that the tested value is valid
        /// </summary>
        /// <value>The error message.</value>
        public string Error
        {
            get;
            private set;
        }

        #endregion Properties
    }
}