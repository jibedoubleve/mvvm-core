namespace Probel.Mvvm.Test
{
    using System;
    using System.Windows;

    using NUnit.Framework;

    using Probel.Mvvm.Core;

    [TestFixture]
    public class WinManagerTest
    {
        #region Methods

        [Test]
        public void CantBindTwice()
        {
            var win = new WinManager();
            win.Bind(() => new Window(), typeof(bool));
            Assert.Throws<ArgumentException>(() => win.Bind(() => new Window(), typeof(bool)));
        }

        #endregion Methods
    }
}