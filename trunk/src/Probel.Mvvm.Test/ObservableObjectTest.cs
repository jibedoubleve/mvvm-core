namespace Probel.Mvvm.Test
{
    using System;

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

            var poco = new Poco();

            poco.PropertyChanged += (sender, e) =>
            {
                triggered = true;
                propertyName = e.PropertyName;
            };

            poco.TriggerOnLambda = "new value";

            Assert.IsTrue(triggered, "The event wasn't triggered");
            Assert.IsTrue(propertyName == Poco.PropName_TriggerOnLambda, "The property name is not the expected one");
        }

        [Test]
        public void CanTriggerOnString()
        {
            var triggered = false;
            var propertyName = string.Empty;

            var poco = new Poco();

            poco.PropertyChanged += (sender, e) =>
            {
                triggered = true;
                propertyName = e.PropertyName;
            };

            poco.TriggerOnString = "new value";

            Assert.IsTrue(triggered, "The event wasn't triggered");
            Assert.IsTrue(propertyName == Poco.PropName_TriggerOnString, "The property name is not the expected one");
        }

        #endregion Methods

        #if DEBUG

        [Test]
        public void FailToTrigger()
        {
            var propertyName = string.Empty;
            var poco = new Poco();

            poco.PropertyChanged += (sender, e) => propertyName = e.PropertyName;

            Assert.Throws<InvalidOperationException>(() => poco.Failure = "new value");
        }

        #endif
    }
}