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
namespace Probel.Mvvm.Behaviours
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Provides a way to add an action on different behaviours of a Calendar
    /// </summary>
    public class CalendarBehaviour
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedDatesChangedProperty = DependencyProperty.RegisterAttached("SelectedDatesChanged"
            , typeof(ICommand)
            , typeof(CalendarBehaviour)
            , new UIPropertyMetadata(null, GetSelectedDatesChangedPropertyCallback));

        private static Dictionary<DependencyObject, Behaviour> behaviours = new Dictionary<DependencyObject, Behaviour>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Sets the selection changed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="command">The command.</param>
        [AttachedPropertyBrowsableForChildren]
        public static void SetSelectedDatesChanged(DependencyObject target, ICommand command)
        {
            target.SetValue(CalendarBehaviour.SelectedDatesChangedProperty, command);
        }

        private static void GetSelectedDatesChangedPropertyCallback(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is Calendar)
            {
                if (!behaviours.ContainsKey(target))
                {
                    behaviours.Add(target, new Behaviour(target as Calendar));
                }
            }
        }

        #endregion Methods

        #region Nested Types

        private class Behaviour
        {
            #region Fields

            private readonly Calendar Calendar;

            #endregion Fields

            #region Constructors

            public Behaviour(Calendar calendar)
            {
                this.Calendar = calendar;
                this.Calendar.SelectedDatesChanged += (sender, e) =>
                {
                    var element = sender as UIElement;
                    if (sender == null) throw new NullReferenceException("Sender is null");

                    var command = (ICommand)element.GetValue(CalendarBehaviour.SelectedDatesChangedProperty);

                    if (command.CanExecute(null))
                    {
                        command.Execute(null);
                    }
                };
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}