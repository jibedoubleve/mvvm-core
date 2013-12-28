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
namespace Probel.Mvvm.Gui
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reflection;

    /// <summary>
    /// This class handles one shot events
    /// </summary>
    /// <typeparam name="TEventSource">The type of the event source.</typeparam>
    public class OneShotHandler<TEventSource> : IDisposable
    {
        #region Fields

        /// <summary>
        /// The source of the event
        /// </summary>
        protected readonly TEventSource Source;

        private IDisposable Subscription;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OneShotHandler{TEventSource}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public OneShotHandler(TEventSource source)
        {
            this.Source = source;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Subscription.Dispose();
        }

        /// <summary>
        /// Handles the specified event when trigered and unsubscribe to it once it was handled.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="handler">The handler which handles the event.</param>
        public void Handle(string eventName, Action<EventPattern<object>> handler)
        {
            var observable = Observable.FromEventPattern(this.Source, eventName);
            this.Subscription = observable.Subscribe(handler, () => Subscription.Dispose());
        }

        #endregion Methods
    }
}