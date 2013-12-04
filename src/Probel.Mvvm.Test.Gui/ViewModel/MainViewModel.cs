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
namespace Probel.Mvvm.Test.Gui.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;

    public class MainViewModel : ObservableObject
    {
        #region Fields

        private readonly ICommand selectedDatesChangedCommand;
        private readonly ICommand showWindowCommand;

        private DateTime selectedDate;

        #endregion Fields

        #region Constructors

        public MainViewModel()
        {
            this.selectedDatesChangedCommand = new RelayCommand(this.SelectedDatesChanged, this.CanSelectedDatesChanged);
            this.showWindowCommand = new RelayCommand(this.ShowWindow, this.CanShowWindow);
        }

        #endregion Constructors

        #region Properties

        public DateTime SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;
                this.OnPropertyChanged(() => SelectedDate);
            }
        }

        public ICommand SelectedDatesChangedCommand
        {
            get { return this.selectedDatesChangedCommand; }
        }

        public ICommand ShowWindowCommand
        {
            get { return this.showWindowCommand; }
        }

        #endregion Properties

        #region Methods

        private bool CanSelectedDatesChanged()
        {
            return this.SelectedDate > DateTime.MinValue;
        }

        private bool CanShowWindow()
        {
            return true;
        }

        private void SelectedDatesChanged()
        {
            ViewService.MessageBox.Asterisk(string.Format("A date changed [{0}]", this.SelectedDate.ToString()));
        }

        private void ShowWindow()
        {
            ViewService.Manager.Show<ModalViewModel>(
                vm => ViewService.MessageBox.Asterisk("Before"),
                vm => ViewService.MessageBox.Asterisk("After"));
        }

        #endregion Methods
    }
}