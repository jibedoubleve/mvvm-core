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
    using NUnit.Framework;

    [TestFixture]
    public class LazyLoaderTest
    {
        #region Methods

        [Test]
        public void Configuration_AddLazyItem_AlwaysSameInstanceIsReturned()
        {
            LazyLoader.Set<SomeType>(() => new SomeType(15));

            var item1 = LazyLoader.Get<SomeType>();
            var item2 = LazyLoader.Get<SomeType>();

            Assert.IsTrue(object.ReferenceEquals(item1, item2));

            item2.Id = 150;

            Assert.AreEqual(item1.Id, item2.Id);
        }

        [SetUp]
        public void _Setup()
        {
            LazyLoader.Clear();
        }

        #endregion Methods

        #region Nested Types

        public class SomeType
        {
            #region Constructors

            public SomeType(int id)
            {
                this.Id = id;
            }

            #endregion Constructors

            #region Properties

            public int Id
            {
                get;
                set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}