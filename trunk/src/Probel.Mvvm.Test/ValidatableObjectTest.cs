namespace Probel.Mvvm.Test
{
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

            Assert.Throws<ExistingRuleException>(() => user.AddRule(() => user.Name
                , "Oops"
                , () => !user.Name.ToLower().StartsWith("a")));
        }

        #endregion Methods
    }
}