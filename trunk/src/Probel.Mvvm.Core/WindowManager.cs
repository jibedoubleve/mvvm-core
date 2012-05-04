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

    public class WindowManager : IWindowManager
    {
        #region Fields

        private static Dictionary<Type, Func<Window>> bindingCollection = new Dictionary<Type, Func<Window>>();

        #endregion Fields

        #region Constructors

        public WindowManager()
        {
            this.ThrowsIfNotBinded = true;
        }

        public WindowManager(bool throwsIfNotBinded)
        {
            this.ThrowsIfNotBinded = ThrowsIfNotBinded;
        }

        #endregion Constructors

        #region Properties

        public bool ThrowsIfNotBinded
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public void Bind(Func<Window> ctor, Type type)
        {
            if (bindingCollection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            bindingCollection.Add(type, ctor);
        }

        public void Bind<TViewModel>(Func<Window> ctor)
        {
            var type = typeof(TViewModel);

            if (bindingCollection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            bindingCollection.Add(type, ctor);
        }

        public void Bind<TView, TViewModel>()
            where TView : Window, new()
        {
            this.Bind<TViewModel>(() => new TView());
        }

        public void Reset()
        {
            bindingCollection.Clear();
        }

        public void Show<TViewModel>()
        {
            var type = typeof(TViewModel);

            if (!bindingCollection.ContainsKey(type))
            {
                if (this.ThrowsIfNotBinded) { throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type)); }
                else { return; }
            }

            var win = bindingCollection[typeof(TViewModel)]();
            if (win != null) win.Show();
        }

        public bool? ShowDialog<TViewModel>()
        {
            var type = typeof(TViewModel);

            if (!bindingCollection.ContainsKey(type))
            {
                if (this.ThrowsIfNotBinded) { throw new KeyNotFoundException(string.Format("Nothing is binded to the type '{0}'", type)); }
                else { return null; }
            }

            var win = bindingCollection[type]();
            if (win != null) return win.ShowDialog();
            else return null;
        }

        #endregion Methods
    }
}