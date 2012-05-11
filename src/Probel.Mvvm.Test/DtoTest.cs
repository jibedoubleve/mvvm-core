namespace Probel.Mvvm.Test
{
    using System;

    using NUnit.Framework;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Test.Helpers;

    [TestFixture]
    public class DtoTest
    {
        #region Methods

        [Test]
        public void CanCompareSameDto()
        {
            var user1 = new UserDto() { Id = 1 };
            var user2 = new UserDto() { Id = 1 };

            var comparer = new BaseDtoComparer<int>();

            Assert.IsTrue(comparer.Equals(user1, user2));
        }

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

        [Test]
        public void FailToCompareDifferentTypes()
        {
            var user = new UserDto() { Id = 1 };
            var book = new BookDto() { Id = 1 };

            var comparer = new BaseDtoComparer<int>();

            Assert.IsFalse(comparer.Equals(user, book));
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