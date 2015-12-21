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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other
    /// objects by invoking delegates. The default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayAsyncCommand : ICommand
    {
        #region Fields

        /// <summary>
        /// Null to indicate the command is empty
        /// </summary>
        public static readonly ICommand Empty = null;

        private readonly Func<bool> canExecute;
        private readonly Func<Task> execute;

        private long isExecuting;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayAsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayAsyncCommand(Func<Task> execute)
            : this(execute, null)
        {
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null) { CommandManager.RequerySuggested += value; }
            }
            remove
            {
                if (this.canExecute != null) { CommandManager.RequerySuggested -= value; }
            }
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (Interlocked.Read(ref isExecuting) != 0)
                return false;

            return canExecute == null ? true : CanExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public async void Execute(object parameter)
        {
            Interlocked.Exchange(ref isExecuting, 1);
            RaiseCanExecuteChanged();

            try
            {
                await execute();
            }
            finally
            {
                Interlocked.Exchange(ref isExecuting, 0);
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Forces the System.Windows.Input.CommandManager to raise the System.Windows.Input.CommandManager.RequerySuggested
        /// event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion Methods
    }
}