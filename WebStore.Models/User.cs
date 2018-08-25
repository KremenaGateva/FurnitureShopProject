namespace WebStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class User : IdentityUser
    {
        [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string FirstName { get; set; }

        [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string LastName { get; set; }

        [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string Country { get; set; }

        [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string Town { get; set; }

        [MinLength(
          ModelsValidationConstants.AddressMinLength,
          ErrorMessage = ErrorMessages.Models.AddressMinLength)]
        [MaxLength(
          ModelsValidationConstants.AddressMaxLength,
          ErrorMessage = ErrorMessages.Models.AddressMaxLength)]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
