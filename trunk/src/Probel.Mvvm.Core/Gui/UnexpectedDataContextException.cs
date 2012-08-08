#region Header

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

#endregion Header

namespace Probel.Mvvm.Gui
{
    using System;

    using Probel.Mvvm.Properties;

    /// <summary>
    /// This exception is thrown when the DataContext of the specified Window is not of the expected type
    /// </summary>
    [Serializable]
    public class UnexpectedDataContextException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedDataContextException"/> class.
        /// </summary>
        /// <param name="expected">The expected.</param>
        /// <param name="current">The current.</param>
        public UnexpectedDataContextException(Type expected, Type current)
            : this(string.Format(Messages.UnexpectedDataContextException, expected, current))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedDataContextException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public UnexpectedDataContextException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedDataContextException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public UnexpectedDataContextException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedDataContextException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected UnexpectedDataContextException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors
    }
}