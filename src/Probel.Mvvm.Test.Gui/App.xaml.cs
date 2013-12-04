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
namespace Probel.Mvvm.Test.Gui
{
    using System.Windows;

    using Probel.Mvvm.Gui;
    using Probel.Mvvm.Test.Gui.View;
    using Probel.Mvvm.Test.Gui.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            var rootwindow = new MainView();

            ViewService.Configure(e =>
            {
                e.RootWindow = rootwindow;
                e.Bind<ModalView, ModalViewModel>();
            });
            rootwindow.Show();
        }

        #endregion Constructors
    }
}