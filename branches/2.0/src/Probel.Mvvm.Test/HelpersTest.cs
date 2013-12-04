namespace Probel.Mvvm.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    using Probel.Mvvm.Helpers;

    [TestFixture]
    public class HelpersTest
    {
        #region Methods

        [Test]
        public void Find_NameOfProperty_NameFound()
        {
            var name = NameOf<MyClass>.Property(e => e.MyProperty);
            Assert.AreEqual("MyProperty", name);
        }

        #endregion Methods

        #region Nested Types

        private class MyClass
        {
            #region Properties

            public int MyProperty
            {
                get; set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}