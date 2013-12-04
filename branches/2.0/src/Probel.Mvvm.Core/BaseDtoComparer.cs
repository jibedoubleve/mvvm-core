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
namespace Probel.Mvvm
{
    using System.Collections.Generic;

    /// <summary>
    /// Compare BaseDto by its Id
    /// </summary>
    /// <typeparam name="TId">The type of the id.</typeparam>
    public class BaseDtoComparer<TId> : IEqualityComparer<BaseDto<TId>>
    {
        #region Methods

        /// <summary>
        /// Equalses the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public bool Equals(BaseDto<TId> x, BaseDto<TId> y)
        {
            if (x.GetType() != y.GetType()) return false;

            return EqualityComparer<TId>.Default.Equals(x.Id, y.Id);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(BaseDto<TId> obj)
        {
            return obj.Id.GetHashCode();
        }

        #endregion Methods
    }
}