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
namespace Probel.Mvvm.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Properties;

    /// <summary>
    /// This manager will keep links between View and ViewModel to help user to open new windows
    /// just by knowing the type of the ViewModel.
    /// </summary>
    internal class WindowManager : IWindowManager, IWindowConfigurator
    {
        #region Fields

        private Dictionary<Type, Func<Window>> bindingCollection = new Dictionary<Type, Func<Window>>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowManager"/> class.
        /// </summary>
        public WindowManager()
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowManager"/> class.
        /// </summary>
        /// <param name="throwsIfNotBinded">if set to <c>true</c> [throws if not binded].</param>
        public WindowManager(bool throwsIfNotBinded)
        {
            this.ThrowsIfNotBinded = throwsIfNotBinded;
            this.IsUnderTest = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is under test.
        /// That's, if this instance is under test, the View won't be showed when 
        /// using the methods Show() or ShowDialog()
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is under test; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnderTest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to throws an exception if a window is already binded.
        /// </summary>
        /// <value><c>true</c> if an exception should be thrown if the window is already binded; otherwise, <c>false</c>.</value>
        public bool ThrowsIfNotBinded
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Binds the specified lambda to the specified TViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="ctor">The lambda that will create a fresh instance of the Window.</param>
        public IConfigurationExpression<TViewModel> Bind<TViewModel>(Func<Window> ctor)
        {
            this.Bind(ctor, typeof(TViewModel));
            return new ConfigurationExpression<TViewModel>(this);
        }

        /// <summary>
        /// Binds the TView type to the TViewModel.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public IConfigurationExpression<TViewModel> Bind<TView, TViewModel>()
            where TView : Window, new()
        {
            this.Bind(() => new TView(), typeof(TViewModel));
            return new ConfigurationExpression<TViewModel>(this);
        }

        /// <summary>
        /// Binds the specified ctor to the specified type. It means that when user ask to show a window
        /// this specified lambda will returns a fresh instance of a window
        /// </summary>
        /// <param name="ctor">The lambda that should create a fresh instance of a window.</param>
        /// <param name="type">The type linked to the lambda.</param>        
        public void Bind(Func<Window> ctor, Type type)
        {
            if (bindingCollection.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("The type '{0}' is already binded.", type));
            }
            bindingCollection.Add(type, ctor);
        }

        /// <summary>
        /// Resets the whole repository.
        /// </summary>
        public void Reset()
        {
            bindingCollection.Clear();
        }

        /// <summary>
        /// Shows the window linked to the TViewModel type as a modal box.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Show<TViewModel>()
        {
            this.Show<TViewModel>((Action<TViewModel>)null);
        }

        /// <summary>
        /// Shows the window linked to the TViewModel type as a modal box.
        /// If a OnShow action is set, it'll be executed as well.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="beforeShowing">Represent the action to execute before showing the view.</param>
        public void Show<TViewModel>(Action<TViewModel> beforeShowing)
        {
            this.WrappedShow<TViewModel>(win =>
            {
                try
                {
                    if (beforeShowing != null) { beforeShowing((TViewModel)win.DataContext); }
                    if (!this.IsUnderTest) { win.Show(); }
                }
                catch (InvalidCastException ex) { throw new UnexpectedDataContextException(typeof(TViewModel), win.DataContext.GetType(), ex); }
                return null;
            });
        }

        /// <summary>
        /// Shows window linked to the TViewModel type as a dialog box and execute the specified action.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        public bool? ShowDialog<TViewModel>()
        {
            return this.ShowDialog<TViewModel>((Action<TViewModel>)null);
        }

        /// <summary>
        /// Shows window linked to the TViewModel type as a dialog box and execute the specified action.
        /// If a OnShow action is set, it'll be executed as well.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="beforeShowing">Represent the action to execute before showing the view.</param>
        /// <returns></returns>
        public bool? ShowDialog<TViewModel>(Action<TViewModel> beforeShowing)
        {
            return this.WrappedShow<TViewModel>(win =>
            {
                if (beforeShowing != null) { beforeShowing((TViewModel)win.DataContext); }
                if (!this.IsUnderTest) { return win.ShowDialog(); }
                else { return true; }
            });
        }

        /// <summary>
        /// Adds the handler that will be triggered when <see cref="Window"/> will be shown.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="action">The action.</param>
        internal void AddBeforeShowingHandler<TViewModel>(Action<TViewModel> action)
        {
            var ctor = bindingCollection[typeof(TViewModel)];

            bindingCollection[typeof(TViewModel)] = () =>
            {
                var view = ctor();
                if (view.DataContext != null)
                {
                    try
                    {
                        action((TViewModel)view.DataContext);
                    }
                    catch (InvalidCastException ex) { throw new UnexpectedDataContextException(typeof(TViewModel), view.DataContext.GetType(), ex); }
                }
                else { throw new NullDataContextException(); }
                return view;
            };
        }


        /// <summary>
        /// Adds the handler that will be triggered when <see cref="Window"/> will be shown.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="action">The action.</param>
        internal void AddBeforeShowingHandler<TViewModel>(Action action)
        {
            var ctor = bindingCollection[typeof(TViewModel)];

            bindingCollection[typeof(TViewModel)] = () =>
            {
                var view = ctor();
                if (view.DataContext != null)
                {
                    try
                    {
                        action();
                    }
                    catch (InvalidCastException ex) { throw new UnexpectedDataContextException(typeof(TViewModel), view.DataContext.GetType(), ex); }
                }
                else { throw new NullDataContextException(); }
                return view;
            };
        }

        /// <summary>
        /// Add a handler when Closing event of the windows is triggered
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="action">The action.</param>
        internal void OnClosingHandler<TViewModel>(Action<TViewModel> action)
        {
            var ctor = bindingCollection[typeof(TViewModel)];

            bindingCollection[typeof(TViewModel)] = () =>
            {
                var view = ctor();
                if (view.DataContext != null)
                {
                    view.Closing += (sender, e) => action((TViewModel)view.DataContext);
                }
                else { throw new NullDataContextException(); }
                return view;
            };
        }

        /// <summary>
        /// Add a handler when Closing event of the windows is triggered
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="action">The action.</param>
        internal void OnClosingHandler<TViewModel>(Action action)
        {
            var ctor = bindingCollection[typeof(TViewModel)];

            bindingCollection[typeof(TViewModel)] = () =>
            {
                var view = ctor();
                if (view.DataContext != null)
                {
                    view.Closing += (sender, e) => action();
                }
                else { throw new NullDataContextException(); }
                return view;
            };
        }

        private bool? WrappedShow<TViewModel>(Func<Window, bool?> action)
        {
            var type = typeof(TViewModel);

            if (!bindingCollection.ContainsKey(type))
            {
                if (this.ThrowsIfNotBinded) { throw new KeyNotFoundException(string.Format(Messages.KeyNotFoundException, type)); }
                else { return null; }
            }

            var win = bindingCollection[type]();
            if (win != null)
            {
                if (win.DataContext is TViewModel)
                {
                    try
                    {
                        if (win.DataContext is IRequestCloseViewModel)
                        {
                            (win.DataContext as IRequestCloseViewModel).CloseRequested += (sender, e) => win.Close();
                        }
                        return action(win);
                    }
                    catch (InvalidCastException ex) { throw new UnexpectedDataContextException(typeof(TViewModel), win.DataContext.GetType(), ex); }

                }
                else if (win.DataContext == null) { throw new NullDataContextException(); }
                else { throw new UnexpectedDataContextException(typeof(TViewModel), win.DataContext.GetType()); }
            }
            else return null;
        }

        #endregion Methods
    }
}