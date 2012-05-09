namespace Probel.Mvvm.Validation
{
    /// <summary>
    /// This is a mocked validator. This does no validation
    /// </summary>
    internal class EmptyValidator : IValidator
    {
        #region Properties

        public string Error
        {
            get { return null; }
        }

        #endregion Properties

        #region Methods

        public void SetValidationLogic(ValidatableObject item)
        {
            //Always valid
        }

        #endregion Methods
    }
}