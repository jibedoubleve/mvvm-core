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
    using System.Windows.Input;

    /// <summary>
    /// Provides additional features to the ICommand
    /// </summary>
    public static class CommandExtension
    {
        #region Methods

        /// <summary>
        /// Executes if the specified <see cref="ICommand"/> with <c>NULL</c> argument if it can be executed.
        /// </summary>
        /// <param name="command">The command to try to execute.</param>
        public static void TryExecute(this ICommand command)
        {
            command.TryExecute(null);
        }

        /// <summary>
        /// Executes if the specified <see cref="ICommand"/> with the specified argument if it can be executed.
        /// </summary>
        /// <param name="command">The command to try to execute.</param>
        /// <param name="arg">The arg specified in the command.</param>
        public static void TryExecute(this ICommand command, object arg)
        {
            if (command.CanExecute(arg))
            {
                command.Execute(arg);
            }
        }

        #endregion Methods
    }
}