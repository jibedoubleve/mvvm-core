namespace Probel.Mvvm.Test
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using NUnit.Framework;

    using Probel.Mvvm.Gui;

    [TestFixture]
    public class WinManagerTest
    {
        #region Fields

        private WindowManager windowManager = new WindowManager();

        #endregion Fields

        #region Methods

        [Test]
        public void CanConfigureUnbinded()
        {
            this.windowManager.Bind(() => null, typeof(object));

            this.windowManager.ThrowsIfNotBinded = true;
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());

            this.windowManager.ThrowsIfNotBinded = false;
            this.windowManager.ShowDialog<bool>();
        }

        [Ignore]
        [Test]
        public void CanListenProperties()
        {
            Assert.Fail("Please write the tests...");
        }

        [Test]
        public void CantBindTwice()
        {
            this.windowManager.Bind(() => new Window(), typeof(object));
            Assert.Throws<ArgumentException>(() => this.windowManager.Bind(() => new Window(), typeof(object)));
        }

        [SetUp]
        public void SetUp()
        {
            this.windowManager.Reset();
            this.windowManager.ThrowsIfNotBinded = true;
        }

        [Test]
        public void ThrowsOnUnbinded()
        {
            this.windowManager.Bind(() => null, typeof(object));
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());
        }

        #endregion Methods
    }
}