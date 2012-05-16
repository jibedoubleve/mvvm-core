namespace Probel.Mvvm.Test
{
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using Probel.Mvvm.DataBinding;
    using System;

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

        [Test]
        public void NullItemThrowNullReferenceException()
        {
            int[] array = null;

            ObservableCollection<int> observableCollection = null;
            Assert.Throws<ArgumentException>(() => observableCollection.Refill(new int[] { 1, 2 }), "First argument");

            observableCollection = new ObservableCollection<int>();
            Assert.Throws<ArgumentException>(() => observableCollection.Refill(array), "Second argument");
        }

        #endregion Methods
    }
}