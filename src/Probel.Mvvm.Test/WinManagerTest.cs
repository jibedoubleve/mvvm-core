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
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using NSubstitute;

    using NUnit.Framework;

    using Probel.Mvvm.Gui;

    [TestFixture]
    public class WinManagerTest
    {
        #region Fields

        private WindowManager windowManager = new WindowManager();

        #endregion Fields

        #region Nested Interfaces

        public interface IOtherViewModel
        {
            #region Methods

            void Closing();

            void Refresh();

            #endregion Methods
        }

        public interface IViewModel
        {
            #region Methods

            void Closing();

            void Refresh();

            #endregion Methods
        }

        #endregion Nested Interfaces

        #region Methods

        [Test]
        public void Configuration_AddAlreadyBindedItem_ArgumentExceptionThrown()
        {
            this.windowManager.Bind<Window, object>();
            Assert.Throws<ArgumentException>(() => this.windowManager.Bind<Window, object>());
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnAddClosingHandler_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            windowManager.Bind<IOtherViewModel>(() => view)
                         .OnClosing(vm => vm.Closing());
            windowManager.ShowDialog<IOtherViewModel>();
            view.Close();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnAddShowingHandler_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            windowManager.Bind<IOtherViewModel>(() => new View(viewmodel))
                         .OnShow(vm => vm.Refresh());
            windowManager.Show<IOtherViewModel>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnShowDialog_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            windowManager.Bind<IOtherViewModel>(() => new View(viewmodel));
            windowManager.ShowDialog<IOtherViewModel>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnShow_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            windowManager.Bind<IOtherViewModel>(() => new View(viewmodel));
            windowManager.Show<IOtherViewModel>();
        }

        [Test]
        public void Configuration_AddUnbindedViewModel_ViewModelBinded()
        {
            this.windowManager.Bind<Window, int>();

            this.windowManager.ThrowsIfNotBinded = true;
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());

            this.windowManager.ThrowsIfNotBinded = false;
            this.windowManager.ShowDialog<bool>();
        }

        [Test]
        public void Configuration_BindTwiceTheSameViewModel_ArgumentExceptionIsThrown()
        {
            this.windowManager.Bind(() => new Window(), typeof(object));
            Assert.Throws<ArgumentException>(() => this.windowManager.Bind(() => new Window(), typeof(object)));
        }

        [Test]
        public void Configuration_CanSetIfExceptionIsThrownOnMultipleBinding_ExceptionIsThrownIfConfigured()
        {
            this.windowManager.Bind(() => null, typeof(object));

            this.windowManager.ThrowsIfNotBinded = true;
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());

            this.windowManager.ThrowsIfNotBinded = false;
            this.windowManager.ShowDialog<bool>();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnClosing_ActionIsExecutedOnClosing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            windowManager.Bind<IViewModel>(() => view)
                         .OnClosing(vm => vm.Refresh());

            windowManager.Show<IViewModel>();

            viewmodel.Received(0).Refresh();

            view.Close();

            viewmodel.Received().Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShowAndAddOneTimeOnShow_ActionnIsExecutedBeforeShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();

            windowManager.Bind<IViewModel>(() => new View(viewmodel))
                         .OnShow(vm => vm.Refresh());

            windowManager.ShowDialog<IViewModel>(vm => vm.Refresh());

            viewmodel.Received(2).Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShowAndOnClosing_ActionIsExecutedBeforeAndAfterShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            windowManager.Bind<IViewModel>(() => view)
                         .OnShow(vm => vm.Refresh())
                         .OnClosing(vm => vm.Closing());

            viewmodel.Received(0).Refresh();
            viewmodel.Received(0).Closing();

            windowManager.ShowDialog<IViewModel>();

            viewmodel.Received(0).Closing();

            view.Close();

            viewmodel.Received().Closing();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShow_ActionnIsExecutedBeforeShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();

            windowManager.Bind<IViewModel>(() => new View(viewmodel))
                         .OnShow(vm => vm.Refresh());

            windowManager.ShowDialog<IViewModel>();

            viewmodel.Received().Refresh();
        }

        [SetUp]
        public void SetUp()
        {
            this.windowManager.Reset();
            this.windowManager.ThrowsIfNotBinded = true;
            this.windowManager.IsUnderTest = true;
        }

        [Test]
        public void ShowWindow_ShowUnbindedWindow_KeyNotFoundExceptionIsThrown()
        {
            this.windowManager.Bind(() => null, typeof(object));
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());
        }

        [Test]
        public void ShowWindow_TryToShowUnbindedViewModel_KeyNotFoundExceptionThrown()
        {
            this.windowManager.Bind<Window, int>();

            this.windowManager.ThrowsIfNotBinded = true;
            Assert.Throws<KeyNotFoundException>(() => this.windowManager.ShowDialog<bool>());
        }

        #endregion Methods

        #region Nested Types

        public class View : Window
        {
            #region Constructors

            public View(IViewModel viewmodel)
            {
                this.DataContext = viewmodel;
            }

            public View(IOtherViewModel viewmodel)
            {
                this.DataContext = viewmodel;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}