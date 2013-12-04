#region Header

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

#endregion Header

namespace Probel.Mvvm.Behaviours
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Provides a way to add an action on different behaviours of a TreeView
    /// </summary>
    public class TreeViewBehaviour
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemChangedProperty = 
            DependencyProperty.RegisterAttached("SelectedItemChanged"
                , typeof(ICommand)
                , typeof(TreeViewBehaviour)
                , new UIPropertyMetadata(null, SelectedItemChangedPropertyChangedCallback));

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = 
            DependencyProperty.RegisterAttached("SelectedItem"
                , typeof(object), typeof(TreeViewBehaviour)
                , new UIPropertyMetadata(null, SelectedItemChangedPropertyChangedCallback));

        private static Dictionary<DependencyObject, Behaviour> behaviours = new Dictionary<DependencyObject, Behaviour>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static object GetSelectedItem(DependencyObject target)
        {
            return (object)target.GetValue(TreeViewBehaviour.SelectedItemProperty);
        }

        /// <summary>
        /// Sets the selected item.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        [AttachedPropertyBrowsableForChildren]
        public static void SetSelectedItem(DependencyObject target, object value)
        {
            target.SetValue(TreeViewBehaviour.SelectedItemProperty, value);
        }

        /// <summary>
        /// Sets the selected item changed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="command">The command.</param>
        [AttachedPropertyBrowsableForChildren]
        public static void SetSelectedItemChanged(DependencyObject target, ICommand command)
        {
            target.SetValue(TreeViewBehaviour.SelectedItemChangedProperty, command);
        }

        private static void SelectedItemChangedPropertyChangedCallback(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (!(target is TreeView))
                return;

            if (!behaviours.ContainsKey(target))
                behaviours.Add(target, new Behaviour(target as TreeView));
        }

        #endregion Methods

        #region Nested Types

        private class Behaviour
        {
            #region Fields

            TreeView view;

            #endregion Fields

            #region Constructors

            public Behaviour(TreeView view)
            {
                this.view = view;
                view.SelectedItemChanged += (sender, e) =>
                {
                    TreeViewBehaviour.SetSelectedItem(view, e.NewValue);
                    ExecuteCommand(sender);
                };
            }

            #endregion Constructors

            #region Methods

            private static void ExecuteCommand(object sender)
            {
                var element = (UIElement)sender;
                var command = (ICommand)element.GetValue(TreeViewBehaviour.SelectedItemChangedProperty);

                if (command.CanExecute(null))
                {
                    command.Execute(null);
                }
            }

            #endregion Methods
        }

        #endregion Nested Types
    }
}