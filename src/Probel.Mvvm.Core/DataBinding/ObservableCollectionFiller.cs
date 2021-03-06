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
namespace Probel.Mvvm.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Allow to refill, add items to an ObservableCollection
    /// </summary>
    [Serializable]
    public static class ObservableCollectionFiller
    {
        #region Methods

        /// <summary>
        /// Adds specified collection into the ObservableCollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oCollection">The o collection.</param>
        /// <param name="collection">The collection.</param>
        public static void AddRange<T>(this ObservableCollection<T> oCollection, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                oCollection.Add(item);
            }
        }

        /// <summary>
        /// Clears the ObservableCollection and refill it with the specified collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oCollection">The o collection.</param>
        /// <param name="collection">The collection.</param>
        public static void Refill<T>(this ObservableCollection<T> oCollection, IEnumerable<T> collection)
        {
            if (oCollection == null) throw new ArgumentNullException("oCollection");
            if (collection == null) throw new ArgumentNullException("collection");

            oCollection.Clear();
            oCollection.AddRange(collection);
        }

        #endregion Methods
    }
}