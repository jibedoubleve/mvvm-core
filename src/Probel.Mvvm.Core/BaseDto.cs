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
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Validation;

    /// <summary>
    /// Provide a base class to manage DTO. 
    ///   - It manage object's. That's, it'll say if the state is dirty or clean whenever <see cref="PropertyChanged"/>
    ///     is triggered.
    ///   - It has a default ID
    ///   - It can ignore defined properties during the state analysis phase.
    /// </summary>
    /// <typeparam name="TId">The type of the id.</typeparam>
    public class BaseDto<TId> : ValidatableObject
    {
        #region Fields

        private TId id = default(TId);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDto&lt;TId&gt;"/> class.
        /// </summary>
        /// <param name="validator">The validator to check the data of this instance</param>
        public BaseDto(IValidator validator)
            : base(validator)
        {
            this.Id = default(TId);
            this.State = State.Created;
            this.IgnoredProperties = new HashSet<string>();
            this.validator = validator;

            this.PropertyChanged += (sender, e) => this.UpdateState(e.PropertyName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDto&lt;TId&gt;"/> class.
        /// </summary>
        public BaseDto()
            : this(new EmptyValidator())
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the id of this DTO.
        /// </summary>
        /// <value>The id.</value>
        public TId Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the state. That's if this instance is clean, created, removed or updated
        /// </summary>
        /// <value>The state.</value>
        public State State
        {
            get;
            private set;
        }

        private HashSet<string> IgnoredProperties
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Cleans the state of this instance.
        /// </summary>
        public void Clean()
        {
            this.State = State.Clean;
        }

        /// <summary>
        /// Set the state of this instance to Removed
        /// </summary>
        public void Remove()
        {
            this.State = State.Removed;
        }

        /// <summary>
        /// Ignores the specified properties. That's, modification of these properties won't modify the state of this instance
        /// </summary>
        /// <param name="properties">The properties.</param>
        protected void Ignore<TProperty>(params Expression<Func<TProperty>>[] properties)
        {
            foreach (var property in properties)
            {
                this.IgnoredProperties.Add(property.GetMemberInfo().Name);
            }
        }

        private void UpdateState(string propertyName)
        {
            if (this.State != State.Removed
                && this.State != State.Created
                && !this.IgnoredProperties.Contains(propertyName))
            {
                this.State = State.Updated;
            }
        }

        #endregion Methods
    }
}