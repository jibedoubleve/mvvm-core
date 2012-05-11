/*
    This file is part of Probel.Mvvm.

    Probel.Mvvm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Probel.Mvvm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Probel.Mvvm.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.Mvvm.Validation
{
    /// <summary>
    /// Set all the validation rules to a <see cref="ValidatableObject"/>
    /// </summary>
    public interface IValidator
    {
        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        string Error
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the validation rules for the specified instance.
        /// </summary>
        /// <param name="item">The item.</param>
        void SetValidationLogic(ValidatableObject item);

        #endregion Methods
    }
}