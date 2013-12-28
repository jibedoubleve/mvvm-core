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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.Mvvm.Test.Gui.Helpers;

    public class MainViewModel : ObservableObject
    {
        #region Fields

        private readonly ICommand selectedDatesChangedCommand;
        private readonly ICommand showWindowCommand;
        private readonly ICommand testInpcCommand;
        private readonly ICommand testValidationCommand;

        private DateTime selectedDate;
        private string testInpcResult;

        #endregion Fields

        #region Constructors

        public MainViewModel()
        {
            this.selectedDatesChangedCommand = new RelayCommand(this.SelectedDatesChanged, this.CanSelectedDatesChanged);
            this.showWindowCommand = new RelayCommand(this.ShowWindow, this.CanShowWindow);

            this.testInpcCommand = new RelayCommand(this.TestInpc);
            this.testValidationCommand = new RelayCommand(this.TestValidation);
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

        public ICommand TestInpcCommand
        {
            get { return this.testInpcCommand; }
        }

        public string Result
        {
            get { return this.testInpcResult; }
            set
            {
                this.testInpcResult = value;
                this.OnPropertyChanged(() => Result);
            }
        }

        public ICommand TestValidationCommand
        {
            get { return this.testValidationCommand; }
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

        private List<MockInpc> Initialise()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = new List<MockInpc>();
            for (int i = 0; i < 100 * 1000; i++)
            {
                list.Add(new MockInpc());
            }
            stopwatch.Stop();
            this.Result += string.Format("Initialisation: {0:N} sec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
            return list;
        }

        private void Manual(List<MockInpc> list)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            foreach (var item in list)
            {
                item.Manual = string.Empty;
            }
            stopwatch.Stop();
            this.Result += string.Format("Manual: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
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

        private void TestInpc()
        {
            this.Result = string.Empty;
            var stopwatch = new Stopwatch();

            var list = Initialise();
            this.WithLambda(list);
            this.Manual(list);
            this.WithDeactivatedLambda(list);
        }

        private void TestValidation()
        {
            this.Result = string.Empty;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10 * 1000; i++)
            {
                new SimpleBookDto();
            }
            stopwatch.Stop();
            this.Result += string.Format("Simple book: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);

            stopwatch.Start();
            for (int i = 0; i < 10 * 1000; i++)
            {
                new BookDto();
            }
            stopwatch.Stop();
            this.Result += string.Format("Book: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private void WithDeactivatedLambda(List<MockInpc> list)
        {
            foreach (var item in list) { item.IsInpcActive = false; }

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            foreach (var item in list)
            {
                item.Manual = string.Empty;
            }
            stopwatch.Stop();
            this.Result += string.Format("With deactivated lambda: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private void WithLambda(List<MockInpc> list)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            foreach (var item in list)
            {
                item.Lambda = string.Empty;
            }
            stopwatch.Stop();
            this.Result += string.Format("With lambda: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        #endregion Methods
    }
}