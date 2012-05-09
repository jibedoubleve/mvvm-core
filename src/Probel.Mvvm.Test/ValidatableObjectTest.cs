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

            Assert.Throws<ExistingValidationRuleException>(() => user.AddValidationRule(() => user.Name, () => !user.Name.ToLower().StartsWith("a"), "Oops"));
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