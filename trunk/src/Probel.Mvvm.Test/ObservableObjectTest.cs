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