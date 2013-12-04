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
namespace Probel.Mvvm.Test.Helpers
{
    using Probel.Mvvm.DataBinding;

    public class Observable : ObservableObject
    {
        #region Fields

        public const string PropName_TriggerOnLambda = "TriggerOnLambda";
        public const string PropName_TriggerOnString = "TriggerOnString";

        private string failure = string.Empty;
        private string triggerOnLambda = string.Empty;
        private string triggerOnString = string.Empty;

        #endregion Fields

        #region Properties

        public string TriggerOnLambda
        {
            get { return this.triggerOnLambda; }
            set
            {
                this.triggerOnLambda = value;
                this.OnPropertyChanged(() => this.TriggerOnLambda);
            }
        }

        #endregion Properties
    }
}