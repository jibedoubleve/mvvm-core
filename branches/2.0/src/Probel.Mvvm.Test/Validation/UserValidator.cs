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
namespace Probel.Mvvm.Test.Validation
{
    using Probel.Mvvm.Test.Helpers;
    using Probel.Mvvm.Validation;

    /// <summary>
    /// 
    /// </summary>
    public class UserValidator : IValidator
    {
        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get { return "This instance is in error state"; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the validation rules for the specified instance.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetValidationLogic(ValidatableObject item)
        {
            var user = item as User;
            user.AddValidationRule(() => user.Name
                , () => !user.Name.ToLower().StartsWith("r")
                , "This name starts with 'r', it is bad");
        }

        #endregion Methods
    }
}