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
namespace Probel.Mvvm.Gui.MessageBoxes
{
    using System;
    using System.Windows;

    using Probel.Mvvm.Properties;

    /// <summary>
    /// Provide an implementation of IMessageBox using System.Window.MessageBox
    /// </summary>
    internal class WindowsMessageBox : IMessageBox
    {
        #region Methods

        /// <summary>
        /// Opens a message box with an asterisk icon and the title is "Asterisk"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Asterisk(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Asterisk, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        /// <summary>
        /// Opens a message box with an asterisk icon and the title is "Asterisk"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void AsteriskFormat(string message, params object[] args)
        {
            Asterisk(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no/cancel buttons
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <returns>
        ///   <c>True</c> if Yes is clicked, <c>False</c> is No is clicked and <c>Null</c> if Cancel is clicked
        /// </returns>
        public bool? CancelableQuestion(object message)
        {
            var dr = MessageBox.Show(message.ToString(), Messages.Question, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (dr)
            {
                case MessageBoxResult.Cancel: return null;
                case MessageBoxResult.No: return false;
                case MessageBoxResult.Yes: return true;
                default: throw new NotSupportedException(string.Format("The specified DialogResult ({0}) is not supported!", dr.ToString()));
            }
        }

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no/cancel buttons
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        ///   <c>True</c> if Yes is clicked, <c>False</c> is No is clicked and <c>Null</c> if Cancel is clicked
        /// </returns>
        public bool? CancelableQuestionFormat(string message, params object[] args)
        {
            return CancelableQuestion(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with an error icon and the title is "Error"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Error(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Opens a message box with an error icon and the title is "Error"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void ErrorFormat(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with an exclamation icon and the title is "Exclamation"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Exclamation(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Exclamation, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// Opens a message box with an exclamation icon and the title is "Exclamation"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void ExclamationFormat(string message, params object[] args)
        {
            Exclamation(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with an hand icon and the title is "Hand"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Hand(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Hand, MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        /// <summary>
        /// Opens a message box with an hand icon and the title is "Hand"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void HandFormat(string message, params object[] args)
        {
            MessageBox.Show(message, Messages.Hand, MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        /// <summary>
        /// Opens a message box with an information icon and the title is "Information"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Information(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Information, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Opens a message box with an information icon and the title is "Information"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void InformationFormat(string message, params object[] args)
        {
            Information(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with no icon and the title is "None"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="title">The title of the message box.</param>
        public void None(object message, string title)
        {
            MessageBox.Show(message.ToString(), title, MessageBoxButton.OK, MessageBoxImage.None);
        }

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no buttons
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <returns>
        ///   <c>True</c> if Yes is clicked; otherwise <c>False</c>
        /// </returns>
        public bool Question(object message)
        {
            var dr = MessageBox.Show(message.ToString(), Messages.Question, MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (dr)
            {
                case MessageBoxResult.No: return false;
                case MessageBoxResult.Yes: return true;
                default: throw new NotSupportedException(string.Format("The specified DialogResult ({0}) is not supported!", dr.ToString()));
            }
        }

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no buttons
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        ///   <c>True</c> if Yes is clicked; otherwise <c>False</c>
        /// </returns>
        public bool QuestionFormat(string message, params object[] args)
        {
            return Question(string.Format(message, args));
        }

        /// <summary>
        /// Opens a message box with a stop icon and the title is "Stop"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Stop(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Stop, MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        /// <summary>
        /// Opens a message box with a stop icon and the title is "Stop"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void StopFormat(string message, params object[] args)
        {
            Stop(string.Format(message.ToString(), args));
        }

        /// <summary>
        /// Opens a message box with a warning icon and the title is "Warning"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void Warning(object message)
        {
            MessageBox.Show(message.ToString(), Messages.Warning, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Opens a message box with a warning icon and the title is "Warning"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void WarningFormat(string message, params object[] args)
        {
            Warning(string.Format(message, args));
        }

        #endregion Methods
    }
}