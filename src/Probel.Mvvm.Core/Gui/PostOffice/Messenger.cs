namespace Probel.Mvvm.Gui.PostOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provide a way to communicate between ViewModels
    /// </summary>
    public class Messenger : IMessenger
    {
        #region Fields

        private static List<Message> Messages = new List<Message>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Subscribe to the specified type of message
        /// </summary>
        /// <typeparam name="TMessage">The type of the message to subscribe</typeparam>
        /// <param name="action">The action to be executed when this type of message is posted</param>
        public void Post<TValue>(TValue value)
        {
            var message = (from msg in Messages
                           where msg.Type == typeof(TValue)
                           select msg).SingleOrDefault();

            if (message == null) { return; }
            else
            {
                var m = (Message<TValue>)message;
                foreach (var item in m.Actions)
                {
                    ((Action<TValue>)item)(value);
                }
            }
        }

        /// <summary>
        /// Post a value in the pipe. It'll eventually be read by all the subscribers
        /// </summary>
        /// <typeparam name="TValue">The type of the message to be posted</typeparam>
        /// <param name="value">The value to be posted</param>
        public void Subscribe<TMessage>(Action<TMessage> action)
        {
            var msg = (from m in Messages
                       where m.Type == typeof(TMessage)
                       select m).FirstOrDefault();
            if (msg == null)
            {
                msg = new Message<TMessage>(typeof(TMessage));
                Messages.Add(msg);
            }
            ((Message<TMessage>)msg).Subscribe(action);
        }

        #endregion Methods
    }
}