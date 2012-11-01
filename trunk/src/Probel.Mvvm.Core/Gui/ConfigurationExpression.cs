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

namespace Probel.Mvvm.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ConfigurationExpression<TViewModel> : IConfigurationExpression<TViewModel>
    {
        #region Fields

        private readonly WindowManager WindowManager;

        #endregion Fields

        #region Constructors

        public ConfigurationExpression(WindowManager windowManager)
        {
            this.WindowManager = windowManager;
        }

        #endregion Constructors

        #region Methods

        public IConfigurationExpression<TViewModel> OnClosing(Action<TViewModel> action)
        {
            this.WindowManager.OnClosingHandler(action);
            return this;
        }

        public IConfigurationExpression<TViewModel> OnShow(Action<TViewModel> action)
        {
            this.WindowManager.AddBeforeShowingHandler(action);
            return this;
        }

        #endregion Methods
    }
}