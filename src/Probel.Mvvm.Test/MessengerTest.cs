namespace Probel.Mvvm.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Probel.Mvvm.Gui.PostOffice;

    [TestFixture]
    public class MessengerTest
    {
        #region Methods

        [Test]
        public void SendMessageToMultipleSubscribers()
        {
            var sender = new Sender();
            var s1 = new Subscriber();
            var s2 = new Subscriber();
            var s3 = new Subscriber();
            var s4 = new Subscriber();

            sender.Send(180);

            Assert.That(s1.Value, Is.EqualTo(180));
            Assert.That(s2.Value, Is.EqualTo(180));
            Assert.That(s3.Value, Is.EqualTo(180));
            Assert.That(s4.Value, Is.EqualTo(180));
        }

        [Test]
        public void SendMessageToSubscriber()
        {
            var sender = new Sender();
            var s = new Subscriber();
            sender.Send(180);

            Assert.That(s.Value, Is.EqualTo(180));
        }

        #endregion Methods

        #region Nested Types

        private class Sender
        {
            #region Methods

            public void Send(int i)
            {
                var m = new Messenger();
                m.Post(i);
            }

            #endregion Methods
        }

        private class Subscriber
        {
            #region Constructors

            public Subscriber()
            {
                var m = new Messenger();
                m.Subscribe<int>(e => Value = e);
            }

            #endregion Constructors

            #region Properties

            public int Value
            {
                get; private set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}