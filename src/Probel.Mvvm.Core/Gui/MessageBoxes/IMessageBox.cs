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
    /// <summary>
    /// Represents an abstraction of message box
    /// </summary>
    public interface IMessageBox
    {
        #region Methods

        /// <summary>
        /// Opens a message box with an asterisk icon and the title is "Asterisk"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Asterisk(object message);

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no/cancel buttons
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <returns><c>True</c> if Yes is clicked, <c>False</c> is No is clicked and <c>Null</c> if Cancel is clicked</returns>
        bool? CancelableQuestion(object message);

        /// <summary>
        /// Opens a message box with an error icon and the title is "Error"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Error(object message);

        /// <summary>
        /// Opens a message box with an exclamation icon and the title is "Exclamation"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Exclamation(object message);

        /// <summary>
        /// Opens a message box with an hand icon and the title is "Hand"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Hand(object message);

        /// <summary>
        /// Opens a message box with an information icon and the title is "Information"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Information(object message);

        /// <summary>
        /// Opens a message box with no icon and the title is "None"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="title">The title of the message box.</param>
        void None(object message, string title);

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no buttons
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <returns><c>True</c> if Yes is clicked; otherwise <c>False</c></returns>
        bool Question(object message);

        /// <summary>
        /// Opens a message box with a stop icon and the title is "Stop"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Stop(object message);

        /// <summary>
        /// Opens a message box with a warning icon and the title is "Warning"
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Warning(object message);

        #endregion Methods



        /// <summary>
        /// Opens a message box with an asterisk icon and the title is "Asterisk"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void AsteriskFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no/cancel buttons
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns><c>True</c> if Yes is clicked, <c>False</c> is No is clicked and <c>Null</c> if Cancel is clicked</returns>
        bool? CancelableQuestionFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an error icon and the title is "Error"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void ErrorFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an exclamation icon and the title is "Exclamation"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void ExclamationFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an hand icon and the title is "Hand"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void HandFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an information icon and the title is "Information"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void InformationFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with an question icon and the title is "Question" and with yes/no buttons
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns><c>True</c> if Yes is clicked; otherwise <c>False</c></returns>
        bool QuestionFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with a stop icon and the title is "Stop"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void StopFormat(string message, params object[] args);

        /// <summary>
        /// Opens a message box with a warning icon and the title is "Warning"
        /// </summary>
        /// <param name="message">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void WarningFormat(string message, params object[] args);
    }
}