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
namespace Probel.Mvvm.Validation
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
            this.CheckCondition = condition;
            this.Error = error;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the condition to succeed to have a valid property's value.
        /// </summary>
        /// <value>The condition.</value>
        public Func<bool> CheckCondition
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