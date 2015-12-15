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

    #region Enumerations

    /// <summary>
    /// Indicates the states of the dto
    /// </summary>
    [Obsolete("This shouldn't be used anymore. Will be removed in next version")]
    public enum State
    {
        /// <summary>
        /// The DTO was not modified
        /// </summary>
        Clean,
        /// <summary>
        /// The DTO was updated
        /// </summary>
        Updated,
        /// <summary>
        /// The DTO is new and should be inserted into the database
        /// </summary>
        Created,
        /// <summary>
        /// The DTO is deleted and should be deleted from the database
        /// </summary>
        Removed,
    }

    #endregion Enumerations
}