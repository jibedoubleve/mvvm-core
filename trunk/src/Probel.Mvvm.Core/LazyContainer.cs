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

namespace Probel.Mvvm
{
    using System;
    using System.Collections.Generic;

    internal class LazyContainer
    {
        #region Fields

        private Dictionary<Type, Item> dictionary = new Dictionary<Type, Item>();

        #endregion Fields

        #region Methods

        public void Clear()
        {
            this.dictionary.Clear();
        }

        public TType Get<TType>()
        {
            var item = this.dictionary[typeof(TType)];

            if (item.Value == null) { item.Value = (object)item.Ctor(); }

            return (TType)item.Value;
        }

        public void Set<TType>(Func<TType> ctor)
        {
            Func<object> func = () => ctor();
            this.dictionary.Add(typeof(TType), new Item(func));
        }

        #endregion Methods

        #region Nested Types

        private class Item
        {
            #region Constructors

            public Item(Func<object> ctor)
            {
                this.Ctor = ctor;
            }

            #endregion Constructors

            #region Properties

            public Func<object> Ctor
            {
                get;
                set;
            }

            public object Value
            {
                get;
                set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}