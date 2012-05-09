namespace Probel.Mvvm.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Probel.Mvvm.Validation;

    public class BaseDto<TId> : ValidatableObject
    {
        #region Fields

        private TId id = default(TId);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDto&lt;TId&gt;"/> class.
        /// </summary>
        public BaseDto()
        {
            this.Id = default(TId);
            this.State = State.Created;
            this.IgnoredProperties = new HashSet<string>();

            this.PropertyChanged += (sender, e) => this.UpdateState(e.PropertyName);
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