namespace Probel.Mvvm.Test
{
    using NUnit.Framework;

    using Probel.Mvvm.Test.Helpers;

    [TestFixture]
    public class ObservableObjectTest
    {
        #region Methods

        [Test]
        public void CanTriggerOnLambda()
        {
            var triggered = false;
            var propertyName = string.Empty;

            var observable = new Observable();

            observable.PropertyChanged += (sender, e) =>
            {
                triggered = true;
                propertyName = e.PropertyName;
            };

            observable.TriggerOnLambda = "new value";

            Assert.IsTrue(triggered, "The event wasn't triggered");
            Assert.IsTrue(propertyName == Observable.PropName_TriggerOnLambda, "The property name is not the expected one");
        }

        #endregion Methods
    }
}