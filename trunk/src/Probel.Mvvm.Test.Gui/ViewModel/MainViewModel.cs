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
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.Mvvm.Test.Gui.Helpers;

    public class MainViewModel : ObservableObject
    {
        #region Fields

        private readonly ICommand selectedDatesChangedCommand;
        private readonly ICommand showDialogWindowCommand;
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
            this.showWindowCommand = new RelayCommand(this.ShowWindow);
            this.showDialogWindowCommand = new RelayCommand(this.ShowWindow);

            this.testInpcCommand = new RelayCommand(this.TestInpc);
            this.testValidationCommand = new RelayCommand(this.TestValidation);
        }

        #endregion Constructors

        #region Properties

        public string Result
        {
            get { return this.testInpcResult; }
            set
            {
                this.testInpcResult = value;
                this.OnPropertyChanged(() => Result);
            }
        }

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

        public ICommand ShowDialogWindowCommand
        {
            get { return this.showDialogWindowCommand; }
        }

        public ICommand ShowWindowCommand
        {
            get { return this.showWindowCommand; }
        }

        public ICommand TestInpcCommand
        {
            get { return this.testInpcCommand; }
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

        private void SelectedDatesChanged()
        {
            ViewService.MessageBox.Asterisk(string.Format("A date changed [{0}]", this.SelectedDate.ToString()));
        }

        private void ShowDialogWindow()
        {
            ViewService.Manager.ShowDialog<ModalViewModel>(
                vm => ViewService.MessageBox.Asterisk("Before"),
                vm => ViewService.MessageBox.Asterisk("After"));
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

            var t1 = Task.Factory.StartNew<string>(l => this.TestInpcWithLambda(l as List<MockInpc>), list);
            t1.ContinueWith(t => this.Result += t.Result);

            var t2 = Task.Factory.StartNew<string>(l => this.TestInpcManually(l as List<MockInpc>), list);
            t2.ContinueWith(t => this.Result += t.Result);

            var t3 = Task.Factory.StartNew<string>(l => this.TestInpcWithDeactivatedLambda(l as List<MockInpc>), list);
            t3.ContinueWith(t => this.Result += t.Result);

            var t4 = Task.Factory.StartNew<string>(l => this.TestInpcWithDeactivatedLambdaUSING(l as List<MockInpc>), list);
            t4.ContinueWith(t => this.Result += t.Result);
        }

        private string TestInpcManually(List<MockInpc> list)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            foreach (var item in list)
            {
                item.Manual = string.Empty;
            }
            stopwatch.Stop();
            return string.Format("Manual: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private string TestInpcWithDeactivatedLambda(List<MockInpc> list)
        {
            foreach (var item in list) { item.IsInpcActive = false; }

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            foreach (var item in list)
            {
                item.Manual = string.Empty;
            }
            stopwatch.Stop();
            return string.Format("With deactivated lambda: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private string TestInpcWithDeactivatedLambdaUSING(List<MockInpc> list)
        {
            //foreach (var item in list) { item.IsInpcActive = false; }

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            foreach (var item in list)
            {
                using (new ObservableObject.DeactivateEvents(item))
                {
                    item.Manual = string.Empty;
                }
            }
            stopwatch.Stop();
            return string.Format("With deactivated lambda (with using): {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private string TestInpcWithLambda(List<MockInpc> list)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            foreach (var item in list)
            {
                item.Lambda = string.Empty;
            }
            stopwatch.Stop();
            return string.Format("With lambda: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
        }

        private void TestValidation()
        {
            this.Result = string.Empty;
            var iterations = 100 * 1000;
            var msg = new StringBuilder();

            #region books
            var t4 = Task.Factory.StartNew<string>(() =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < iterations; i++) { new BookDto(); }
                stopwatch.Stop();
                return string.Format("Book: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
            });
            t4.ContinueWith(t => this.Result += t.Result);
            #endregion
            #region simple book
            var t2 = Task.Factory.StartNew<string>(() =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < iterations; i++) { new SimpleBookDto(); }
                stopwatch.Stop();
                return string.Format("Simple book: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
            });
            t2.ContinueWith(t => this.Result += t.Result);
            #endregion
            #region validator
            var t3 = Task.Factory.StartNew<string>(() =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < iterations; i++) { new BookValidator(); }
                stopwatch.Stop();
                return string.Format("Instantiate validator: {0:N} msec{1}", stopwatch.Elapsed.TotalSeconds, Environment.NewLine);
            });
            t3.ContinueWith(t => this.Result += t.Result);
            #endregion
        }

        #endregion Methods
    }
}