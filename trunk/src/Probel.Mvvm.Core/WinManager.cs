namespace Probel.Mvvm.Core
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