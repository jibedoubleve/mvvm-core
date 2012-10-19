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
namespace Probel.Mvvm.Test
{
    using System.Windows.Input;

    using NUnit.Framework;

    using Probel.Mvvm.DataBinding;

    [TestFixture]
    public class RelayCommandTest
    {
        #region Methods

        [Test]
        public void CanUseRelayArgCommand()
        {
            var hasBeenExecuted = false;
            ICommand cmd = new RelayArgCommand(e => hasBeenExecuted = (bool)e, e => (bool)e);

            cmd.Execute(true);

            Assert.IsFalse(cmd.CanExecute(false));
            Assert.IsTrue(hasBeenExecuted);
        }

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