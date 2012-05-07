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
namespace Probel.Mvvm.Validation
{
    using System;
    using System.Runtime.Serialization;

    using Probel.Mvvm.Properties;

    /// <summary>
    /// A validation rule has been set for this property
    /// </summary>
    [Serializable]
    public class ExistingRuleException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingRuleException"/> class.
        /// </summary>
        public ExistingRuleException()
            : this(Messages.ExistingRuleException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingRuleException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExistingRuleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingRuleException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ExistingRuleException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingRuleException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ExistingRuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors
    }
}