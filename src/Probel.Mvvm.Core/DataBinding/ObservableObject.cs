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
namespace Probel.Mvvm.DataBinding
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;

    /// <summary>
    /// Basic implementation of <see cref="INotifyPropertyChanged"/>
    /// </summary>
    [Serializable]
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableObject"/> class.
        /// </summary>
        public ObservableObject()
        {
            this.IsInpcActive = true;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether INotifyPropertyChanged triggers when property is changed.        
        /// </summary>
        /// <value>
        ///   <c>true</c> if INotifyPropertyChanged raises events; otherwise, <c>false</c>.
        /// </value>
        public bool IsInpcActive
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Notify the property was changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.VerifyPropertyName(propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            if (this.IsInpcActive)
            {
                this.OnPropertyChanged(property.GetMemberInfo().Name);
            }
        }

        /// <summary>
        /// Warns the developer if this object does not have a public property with
        /// the specified name. This method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            // verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidOperationException(string.Format("Invalid property name \"{0}\" before triggering 'PropertyChanged' event.", propertyName));
            }
        }

        #endregion Methods

        #region Nested Types

        /// <summary>
        /// During the lifetime of this object, the ObservableObject will not raise NotifyPropertyChanged
        /// </summary>
        protected class DeactivateEvents : IDisposable
        {
            #region Fields

            private readonly ObservableObject Observable;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="DeactivateEvents"/> class.
            /// </summary>
            /// <param name="observable">The observable.</param>
            public DeactivateEvents(ObservableObject observable)
            {
                this.Observable = observable;
            }

            #endregion Constructors

            #region Methods

            /// <summary>
            /// When this method is called, the <see cref="ObservableObject"/> linked to this instance
            /// will raise agin NotifyOnPropertyChanged
            /// </summary>
            public void Dispose()
            {
                this.Observable.IsInpcActive = true;
            }

            #endregion Methods
        }

        #endregion Nested Types
    }
}