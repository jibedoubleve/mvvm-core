namespace Probel.Mvvm.Test
{
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using NUnit.Framework;

    using Probel.Mvvm.Converters;

    [TestFixture]
    public class ConversionTest
    {
        #region Methods

        [Test]
        public void ConvertBack_BoolToInvert_FalseBecomesTrue()
        {
            var converter = new InvertBoolConverter();

            var value = (bool)converter.Convert(false, typeof(bool), null, Thread.CurrentThread.CurrentCulture);
            var result = (bool)converter.ConvertBack(value, typeof(bool), null, Thread.CurrentThread.CurrentCulture);

            Assert.IsTrue(value);
            Assert.IsFalse(result);
        }

        [Test]
        public void Convert_BoolToInvert_FalseBecomesTrue()
        {
            var converter = new InvertBoolConverter();

            var value = (bool)converter.Convert(false, typeof(bool), null, Thread.CurrentThread.CurrentCulture);

            Assert.IsTrue(value);
        }

        #endregion Methods
    }
}