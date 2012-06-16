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
namespace Probel.Mvvm.Test
{
    using System;

    using NUnit.Framework;

    using Probel.Mvvm.Test.Helpers;
    using Probel.Mvvm.Validation;

    [TestFixture]
    public class ValidatableObjectTest
    {
        #region Methods

        [Test]
        public void CanManuallyValidate()
        {
            var user = new User("Robert");

            var error = user["Name"];

            Assert.IsNotNull(error);
        }

        [Test]
        public void CannotOverrideRoles()
        {
            var user = new User("Robert");
            var error = user["Name"];

            Assert.IsNotNull(error, "Default validation");

            Assert.Throws<ExistingValidationRuleException>(() =>
            {
                user.AddValidationRule(() => user.Name
                    , () => !user.Name.ToLower().StartsWith("a")
                    , "Oops");
            });
        }

        [Test]
        public void CanValidateDto()
        {
            var book = new BookDto()
            {
                Pages = 1,
                Title = string.Empty,
            };

            Console.WriteLine(book["Pages"]);
            Console.WriteLine(book["Title"]);

            Assert.IsNotNull(book["Pages"]);
            Assert.IsNotNull(book["Title"]);
        }

        #endregion Methods
    }
}