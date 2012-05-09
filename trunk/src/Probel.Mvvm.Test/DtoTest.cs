namespace Probel.Mvvm.Test
{
    using System;

    using NUnit.Framework;

    using Probel.Mvvm.Test.Helpers;
    using Probel.Mvvm.DataBinding;

    [TestFixture]
    public class DtoTest
    {
        #region Methods

        [Test]
        public void CanCreateDto()
        {
            var user = this.CreateUser();

            user.Height = 128;
            Assert.AreEqual(State.Created, user.State);
        }

        [Test]
        public void CanIgnoreProperty()
        {
            var user = this.CreateUser();
            user.Clean();

            user.Birthdate = new DateTime(2010, 1, 1);
            Assert.AreEqual(State.Clean, user.State);
        }

        [Test]
        public void CanRemoveDto()
        {
            var user = this.CreateUser();
            user.Remove();

            user.Height = 128;
            Assert.AreEqual(State.Removed, user.State);
        }

        private UserDto CreateUser()
        {
            var user = new UserDto() { Name = "Luke" };

            Assert.AreEqual(default(int), user.Id, "Wrong ID");
            Assert.AreEqual(State.Created, user.State, "Wrong default state");
            return user;
        }

        #endregion Methods
    }
}