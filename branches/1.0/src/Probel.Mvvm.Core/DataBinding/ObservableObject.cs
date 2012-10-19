﻿/*
    This file is part of Probel.Mvvm.

    Probel.Mvvm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Probel.Mvvm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Probel.Mvvm.  If not, see <http://www.gnu.org/licenses/>.
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
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        protected void OnPropertyChanged<TProperty>(params Expression<Func<TProperty>>[] properties)
        {
            foreach (var property in properties)
            {
                this.OnPropertyChanged(property.GetMemberInfo().Name);
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event on multiple properties changed
        /// </summary>
        /// <param name="propertyName">The name of the property that has a new value.</param>
        private void OnPropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                this.VerifyPropertyName(propertyName);

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
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
    }
}