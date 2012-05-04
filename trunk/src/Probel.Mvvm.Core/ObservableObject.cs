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
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Basic implementation of <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Fields

        private HashSet<string> listenedProperties = new HashSet<string>();

        #endregion Fields

        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public string[] ListenedProperties
        {
            get { return this.listenedProperties.ToArray(); }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        /// <param name="listen">if set to <c>true</c> add the property the the listen list.</param>
        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property, bool listen)
        {
            this.OnPropertyChanged(property, listen);
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            this.OnPropertyChanged(property.GetMemberInfo().Name, false);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has a new value.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(propertyName, false);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has a new value.</param>
        /// <param name="listen">if set to <c>true</c> add the property the the listen list.</param>
        protected void OnPropertyChanged(string propertyName, bool listen)
        {
            this.listenedProperties.Add(propertyName);

            this.VerifyPropertyName(propertyName);

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event on multiple properties changed
        /// </summary>
        /// <param name="propertyName">The name of the property that has a new value.</param>
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            this.OnPropertyChanged(false, propertyNames);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event on multiple properties changed
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        /// <param name="listen">if set to <c>true</c> add the property the the listen list.</param>
        protected void OnPropertyChanged(bool listen, params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                this.OnPropertyChanged(propertyName, listen);
            }
        }

        /// <summary>
        /// Warns the developer if this object does not have a public property with
        /// the specified name. This method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        protected virtual void VerifyPropertyName(string propertyName)
        {
            // verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidOperationException(string.Format("Invalid property name: {0}", propertyName));
            }
        }

        #endregion Methods
    }
}