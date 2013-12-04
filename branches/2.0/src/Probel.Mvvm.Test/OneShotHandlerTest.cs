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

    using Probel.Mvvm.Gui;
    using Probel.Mvvm.Test.Helpers;

    [TestFixture]
    public class OneShotHandlerTest
    {
        #region Methods

        [Test]
        public void Subscribe_ToEvent_NoEventsTriggeredAfterDisposing()
        {
            var eventObject = new EventObject();
            var count = 0;

            using (var handler = new OneShotHandler<EventObject>(eventObject))
            {
                handler.Handle("SomeEvent", e => count = count + 1);

                for (int i = 0; i < 10; i++) { eventObject.OnSomeEvent(); }
            }

            for (int i = 0; i < 10; i++) { eventObject.OnSomeEvent(); }

            Assert.AreEqual(10, count);
        }

        #endregion Methods
    }
}