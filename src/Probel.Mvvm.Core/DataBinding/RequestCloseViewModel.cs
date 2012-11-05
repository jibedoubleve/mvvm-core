#region Header

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

#endregion Header

namespace Probel.Mvvm.DataBinding
{
    using System;

    /// <summary>
    /// Basic implementation of a ViewModel that can ask to the view to close it self
    /// </summary>
    public class RequestCloseViewModel : ObservableObject, IRequestCloseViewModel
    {
        #region Events

        /// <summary>
        /// Occurs when the ViewModel requested to close the Gui item.
        /// </summary>
        public event EventHandler CloseRequested;

        #endregion Events

        #region Methods

        /// <summary>
        /// Closes the view linked to this ViewModel if exist.
        /// </summary>
        public void Close()
        {
            this.OnCloseRequested();
        }

        /// <summary>
        /// Trigger a close request to the view
        /// </summary>
        private void OnCloseRequested()
        {
            if (this.CloseRequested != null) { this.CloseRequested(this, EventArgs.Empty); }
        }

        #endregion Methods
    }
}