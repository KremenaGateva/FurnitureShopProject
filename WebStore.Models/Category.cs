namespace WebStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(
            ModelsValidationConstants.NamesMinLength,
            ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
            ModelsValidationConstants.NamesMaxLength, 
            ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}