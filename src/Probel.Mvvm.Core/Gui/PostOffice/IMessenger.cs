namespace Probel.Mvvm.Gui.PostOffice
{
    using System;

    /// <summary>
    /// Provide a way to communicate between ViewModels
    /// </summary>
    public interface IMessenger
    {
        #region Methods

        /// <summary>
        /// Post a value in the pipe. It'll eventually be read by all the subscribers
        /// </summary>
        /// <typeparam name="TValue">The type of the message to be posted</typeparam>
        /// <param name="value">The value to be posted</param>
        void Post<TValue>(TValue value);

        /// <summary>
        /// Subscribe to the specified type of message
        /// </summary>
        /// <typeparam name="TMessage">The type of the message to subscribe</typeparam>
        /// <param name="action">The action to be executed when this type of message is posted</param>
        void Subscribe<TMessage>(Action<TMessage> action);

        #endregion Methods
    }
}