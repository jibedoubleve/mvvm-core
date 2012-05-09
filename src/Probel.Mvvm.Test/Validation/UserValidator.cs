namespace Probel.Mvvm.Test.Validation
{
    using Probel.Mvvm.Test.Helpers;
    using Probel.Mvvm.Validation;

    /// <summary>
    /// 
    /// </summary>
    public class UserValidator : IValidator
    {
        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get { return "This instance is in error state"; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the validation rules for the specified instance.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SetValidationLogic(ValidatableObject item)
        {
            var user = item as User;
            user.AddValidationRule(() => user.Name
                , () => !user.Name.ToLower().StartsWith("r")
                , "This name starts with 'r', it is bad");
        }

        #endregion Methods
    }
}