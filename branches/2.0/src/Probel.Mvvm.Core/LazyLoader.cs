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
    using System;

    /// <summary>
    /// This container will instanciate only once the configured type and will return always the same
    /// instance
    /// </summary>
    public static class LazyLoader
    {
        #region Fields

        private static readonly LazyContainer Loader = new LazyContainer();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Clears all the bindings from the container.
        /// </summary>
        public static void Clear()
        {
            Loader.Clear();
        }

        /// <summary>
        /// Gets an instance of the specified type. If it is the first time it's asked,
        /// it'll call the configured ctor once and then return the saved instance
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns></returns>
        public static TType Get<TType>()
        {
            return Loader.Get<TType>();
        }

        /// <summary>
        /// Add the specified type in the repository. When it'll be asked an instance
        /// of that type, it'll execute the specified ctor only once and after it'll return
        /// always the same instance.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="ctor">The ctor.</param>
        public static void Set<TType>(Func<TType> ctor)
        {
            Loader.Set<TType>(ctor);
        }

        #endregion Methods
    }
}