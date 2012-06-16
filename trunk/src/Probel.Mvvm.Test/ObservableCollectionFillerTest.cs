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
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using Probel.Mvvm.DataBinding;

    [TestFixture]
    public class ObservableCollectionFillerTest
    {
        #region Methods

        [Test]
        public void CanAddRange()
        {
            var collection = this.CreateCollection();

            collection.AddRange(new int[] { 7, 8, 9, 0 });

            Assert.AreEqual(10, collection.Count);
        }

        [Test]
        public void CanRefillCollection()
        {
            var collection = this.CreateCollection();

            collection.Refill(new int[] { 10, 11 });

            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void NullItemThrowNullReferenceException()
        {
            int[] array = null;

            ObservableCollection<int> observableCollection = null;
            Assert.Throws<ArgumentNullException>(() => observableCollection.Refill(new int[] { 1, 2 }), "First argument");

            observableCollection = new ObservableCollection<int>();
            Assert.Throws<ArgumentNullException>(() => observableCollection.Refill(array), "Second argument");
        }

        private ObservableCollection<int> CreateCollection()
        {
            var collection = new ObservableCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);
            collection.Add(6);
            return collection;
        }

        #endregion Methods
    }
}