/*
    This file is part of Probel.Mvvm.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.Mvvm
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    public class WinManager : IWinManager
    {
        #region Fields

        private static Dictionary<Type, Func<Window>> collection = new Dictionary<Type, Func<Window>>();

        #endregion Fields

        #region Methods

        public void Bind(Func<Window> ctor, Type type)
        {
            if (collection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            collection.Add(type, ctor);
        }

        public void Bind<TType>(Func<Window> ctor)
        {
            var type = typeof(TType);

            if (collection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            collection.Add(type, ctor);
        }

        public void Show<TType>()
        {
            var type = typeof(TType);

            if (!collection.ContainsKey(type))
            {
                throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type));
            }

            collection[typeof(TType)]().Show();
        }

        public void ShowDialog<TType>()
        {
            var type = typeof(TType);

            if (!collection.ContainsKey(type))
            {
                throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type));
            }

            collection[type]().ShowDialog();
        }

        #endregion Methods
    }
}