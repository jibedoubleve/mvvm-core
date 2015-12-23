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
namespace Probel.Mvvm.Test.Helpers
{
    using System;

    public class EventObject
    {
        #region Events

        public event EventHandler SomeEvent;

        #endregion Events

        #region Methods

        public void OnSomeEvent()
        {
            if (this.SomeEvent != null) { this.SomeEvent(this, EventArgs.Empty); }
        }

        #endregion Methods
    }
}