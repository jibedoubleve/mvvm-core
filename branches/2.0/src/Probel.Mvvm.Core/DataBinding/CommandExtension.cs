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