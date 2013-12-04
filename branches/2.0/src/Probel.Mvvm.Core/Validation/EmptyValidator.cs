#region Header

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

#endregion Header

namespace Probel.Mvvm.Validation
{
    /// <summary>
    /// This is a mocked validator. This does no validation
    /// </summary>
    internal class EmptyValidator : IValidator
    {
        #region Properties

        public string Error
        {
            get { return null; }
        }

        #endregion Properties

        #region Methods

        public void SetValidationLogic(ValidatableObject item)
        {
            //Always valid
        }

        #endregion Methods
    }
}