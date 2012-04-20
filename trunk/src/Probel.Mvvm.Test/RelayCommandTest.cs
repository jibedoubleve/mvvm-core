namespace Probel.Mvvm.Test
{
    using System.Windows.Input;

    using NUnit.Framework;

    using Probel.Mvvm;

    [TestFixture]
    public class RelayCommandTest
    {
        #region Methods

        [Test]
        public void CanUseRelayCommand()
        {
            var hasBeenExecuted = false;
            ICommand cmd = new RelayCommand(() => hasBeenExecuted = true, () => false);

            cmd.Execute(null);

            Assert.IsFalse(cmd.CanExecute(null));
            Assert.IsTrue(hasBeenExecuted);
        }

        #endregion Methods
    }
}