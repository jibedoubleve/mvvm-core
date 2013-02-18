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

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Threading;

    [TestFixture]
    public class ViewServiceTest
    {
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
            ViewService.Configure(e => e.Bind<Window, object>());
            Assert.Throws<ArgumentException>(() => ViewService.Configure(e => e.Bind<Window, object>()));
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnAddClosingHandler_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.Bind<IOtherViewModel>(() => view)
                 .OnClosing(vm => vm.Closing());
            });
            ViewService.Manager.ShowDialog<IOtherViewModel>();
            view.Close();
        }
        [Test]
        [STAThread]
        public void ChangeCultureInfo_ShowAView_CultureInfoIsAsConfigured()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.Culture
                    = e.UICulture
                    = new CultureInfo("es");
                e.Bind<IOtherViewModel>(() => view);
            });

            var task = Task.Factory.StartNew(() => 1 + 2);
            task.ContinueWith(t =>
            {
                CultureInfo culture = null;
                ViewService.Manager.ShowDialog<IOtherViewModel>(vm => culture = Thread.CurrentThread.CurrentUICulture);
                view.Close();

                Assert.AreEqual(new CultureInfo("es"), culture);
            });
            task.Wait();
        }
        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnAddShowingHandler_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            ViewService.Configure(e =>
            {
                e.Bind<IOtherViewModel>(() => new View(viewmodel))
                 .OnShow(vm => vm.Refresh());
            });
            ViewService.Manager.Show<IOtherViewModel>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnShowDialog_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            ViewService.Configure(e => e.Bind<IOtherViewModel>(() => new View(viewmodel)));
            ViewService.Manager.ShowDialog<IOtherViewModel>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_AddAnUnexpectedViewModelOnShow_UnexpectedDataContextException()
        {
            var viewmodel = Substitute.For<IViewModel>();

            ViewService.Configure(e => e.Bind<IOtherViewModel>(() => new View(viewmodel)));
            ViewService.Manager.Show<IOtherViewModel>();
        }

        [Test]
        public void Configuration_AddUnbindedViewModel_ViewModelBinded()
        {
            ViewService.Configure(e => e.Bind<Window, int>());

            ViewService.Configure(e => e.ThrowsIfNotBinded = true);
            Assert.Throws<KeyNotFoundException>(() => ViewService.Manager.ShowDialog<bool>());

            ViewService.Configure(e => e.ThrowsIfNotBinded = false);
            ViewService.Manager.ShowDialog<bool>();
        }

        [Test]
        public void Configuration_BindTwiceTheSameViewModel_ArgumentExceptionIsThrown()
        {
            ViewService.Configure(e => e.Bind(() => new Window(), typeof(object)));
            Assert.Throws<ArgumentException>(() => ViewService.Configure(e => e.Bind(() => new Window(), typeof(object))));
        }

        [Test]
        public void Configuration_CanSetIfExceptionIsThrownOnMultipleBinding_ExceptionIsThrownIfConfigured()
        {
            ViewService.Configure(e => e.Bind(() => null, typeof(object)));

            ViewService.Configure(e => e.ThrowsIfNotBinded = true);
            Assert.Throws<KeyNotFoundException>(() => ViewService.Manager.ShowDialog<bool>());

            ViewService.Configure(e => e.ThrowsIfNotBinded = false);
            ViewService.Manager.ShowDialog<bool>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(NullDataContextException))]
        public void Configuration_GetDataContextWithNull_DataContextIsReturned()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View();

            var vm = view.As<IOtherViewModel>();
        }

        [Test]
        [STAThread]
        [ExpectedException(typeof(UnexpectedDataContextException))]
        public void Configuration_GetDataContextWithOtherTypeThanAsked_DataContextIsReturned()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            var vm = view.As<IOtherViewModel>();

            Assert.IsInstanceOf<IViewModel>(vm);
        }

        [Test]
        [STAThread]
        public void Configuration_GetDataContext_DataContextIsReturned()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            var vm = view.As<IViewModel>();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnClosing_ActionIsExecutedOnClosing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var other = Substitute.For<IOtherViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => view)
                 .OnClosing(() => other.Refresh());
            });

            ViewService.Manager.Show<IViewModel>();

            other.Received(0).Refresh();

            view.Close();

            other.Received(1).Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShowAndAddOneTimeOnShow_ActionnIsExecutedBeforeShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => new View(viewmodel))
                 .OnShow(vm => vm.Refresh());
            });

            ViewService.Manager.ShowDialog<IViewModel>(vm => vm.Refresh());

            viewmodel.Received(2).Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShowAndOnClosing_ActionIsExecutedBeforeAndAfterShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => view)
                 .OnShow(vm => vm.Refresh())
                 .OnClosing(vm => vm.Closing());
            });

            viewmodel.Received(0).Refresh();
            viewmodel.Received(0).Closing();

            ViewService.Manager.ShowDialog<IViewModel>();

            viewmodel.Received(1).Refresh();
            viewmodel.Received(0).Closing();

            view.Close();

            viewmodel.Received(1).Refresh();
            viewmodel.Received(1).Closing();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionOnShow_ActionnIsExecutedBeforeShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => new View(viewmodel))
                 .OnShow(vm => vm.Refresh());
            });

            ViewService.Manager.ShowDialog<IViewModel>();

            viewmodel.Received().Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionWithoutArgOnClosing_ActionIsExecutedOnClosing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => view)
                 .OnClosing(vm => vm.Refresh());
            });

            ViewService.Manager.Show<IViewModel>();

            viewmodel.Received(0).Refresh();

            view.Close();

            viewmodel.Received(1).Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetActionWithoutArgOnShow_ActionnIsExecutedBeforeShowing()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var other = Substitute.For<IOtherViewModel>();

            ViewService.Configure(e =>
            {
                e.Bind<IViewModel>(() => new View(viewmodel))
                 .OnShow(() => other.Refresh());
            });

            ViewService.Manager.ShowDialog<IViewModel>();

            other.Received().Refresh();
        }

        [Test]
        [STAThread]
        public void Configuration_SetTheMainWindow_ShowedWindowHasTheSameOwner()
        {
            var viewmodel = Substitute.For<IViewModel>();
            var view = new View(viewmodel);

            ViewService.Configure(e =>
            {
                e.RootWindow = new Window();
                e.Bind<IViewModel>(() => view);
            });

            ViewService.Manager.Show<IViewModel>();

            ViewService.Configure(e => Assert.NotNull(e.RootWindow));
        }

        [Test]
        [STAThread]
        public void ShowWindow_RequestClosing_ViewClosed()
        {
            var viewmodel = Substitute.For<IRequestCloseViewModel>();

            var called = false;

            ViewService.Configure(e =>
            {
                e.Bind<IRequestCloseViewModel>(() => new View(viewmodel))
                 .OnClosing(vm => called = true);
            });

            ViewService.Manager.Show<IRequestCloseViewModel>();

            viewmodel.CloseRequested += Raise.Event();
            Assert.IsTrue(called);
        }

        [Test]
        public void ShowWindow_ShowUnbindedWindow_KeyNotFoundExceptionIsThrown()
        {
            ViewService.Configure(e => e.Bind(() => null, typeof(object)));
            Assert.Throws<KeyNotFoundException>(() => ViewService.Manager.ShowDialog<bool>());
        }

        [Test]
        public void ShowWindow_TryToShowUnbindedViewModel_KeyNotFoundExceptionThrown()
        {
            ViewService.Configure(e =>
            {
                e.Bind<Window, int>();
                e.ThrowsIfNotBinded = true;
            });
            Assert.Throws<KeyNotFoundException>(() => ViewService.Manager.ShowDialog<bool>());
        }

        [SetUp]
        public void _SetUp()
        {
            Thread.CurrentThread.CurrentUICulture
                = Thread.CurrentThread.CurrentCulture
                = new CultureInfo("en");

            ViewService.Configure(e =>
            {
                e.Reset();
                e.ThrowsIfNotBinded = true;
                e.IsUnderTest = true;
            });
        }

        #endregion Methods

        #region Nested Types

        public class View : Window
        {
            #region Constructors

            public View()
            {
            }

            public View(IViewModel viewmodel)
            {
                this.DataContext = viewmodel;
            }

            public View(IOtherViewModel viewmodel)
            {
                this.DataContext = viewmodel;
            }

            public View(IRequestCloseViewModel viewmodel)
            {
                this.DataContext = viewmodel;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}