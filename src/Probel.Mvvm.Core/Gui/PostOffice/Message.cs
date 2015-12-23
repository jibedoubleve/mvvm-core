namespace Probel.Mvvm.Gui.PostOffice
{
    using System;
    using System.Collections.Generic;

    internal class Message
    {
        #region Constructors

        public Message(Type type)
        {
            this.Type = type;
        }

        #endregion Constructors

        #region Properties

        public Type Type
        {
            get; private set;
        }

        #endregion Properties
    }

    internal class Message<T> : Message
    {
        #region Fields

        internal readonly List<Action<T>> Actions = new List<Action<T>>();

        #endregion Fields

        #region Constructors

        public Message(Type type)
            : base(type)
        {
        }

        #endregion Constructors

        #region Methods

        internal void Subscribe(Action<T> action)
        {
            this.Actions.Add(action);
        }

        #endregion Methods
    }
}