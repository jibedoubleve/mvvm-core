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