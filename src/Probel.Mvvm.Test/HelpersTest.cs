﻿/*
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
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    using Probel.Mvvm.Helpers;

    [TestFixture]
    public class HelpersTest
    {
        #region Methods

        [Test]
        public void Find_NameOfProperty_NameFound()
        {
            var name = NameOf<MyClass>.Property(e => e.MyProperty);
            Assert.AreEqual("MyProperty", name);
        }

        #endregion Methods

        #region Nested Types

        private class MyClass
        {
            #region Properties

            public int MyProperty
            {
                get; set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}