namespace Probel.Mvvm.Test
{
    using NUnit.Framework;

    using Probel.Mvvm.Test.Helpers;

    [TestFixture]
    public class ValidatableObjectTest
    {
        #region Methods

        [Test]
        public void CanManuallyValidate()
        {
            var user = new User("Robert");

            var error = user.Validate("Name");

            Assert.IsNotNull(error);
        }

        [Test]
        public void CanOverrideRoles()
        {
            var user = new User("Robert");
            var error = user.Validate("Name");

            Assert.IsNotNull(error, "Default validation");


            user.AddRule(() => user.Name
                , "Oops"
                , () => !user.Name.ToLower().StartsWith("a"));
            error = user.Validate("Name");

            Assert.IsNull(error, "Overriden validation");
        }

        #endregion Methods
    }
}