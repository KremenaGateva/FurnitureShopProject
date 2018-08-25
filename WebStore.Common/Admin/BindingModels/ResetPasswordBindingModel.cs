namespace WebStore.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class ResetPasswordBindingModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
            ModelsValidationConstants.PasswordMaxLength,
            ErrorMessage = ErrorMessages.Models.PasswordLength,
            MinimumLength = ModelsValidationConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = ModelsConstants.DisplayNamesConstants.NewPassword)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = ModelsConstants.DisplayNamesConstants.ConfirmNewPassword)]
        [Compare(nameof(NewPassword), ErrorMessage = ErrorMessages.Models.ConfirmPasswordMatchesPassword)]
        public string ConfirmPassword { get; set; }
    }
}
