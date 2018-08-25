namespace WebStore.Common.DataOperator.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class ProductBindingModel
    {
        [Required]
        [MinLength(
            ModelsValidationConstants.NamesMinLength,
            ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
            ModelsValidationConstants.NamesMaxLength,
            ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string Name { get; set; }

        [MinLength(
            ModelsValidationConstants.DescriptionMinLength,
            ErrorMessage = ErrorMessages.Models.DescriptionMinLength)]
        [MaxLength(
            ModelsValidationConstants.DescriptionMaxLength,
            ErrorMessage = ErrorMessages.Models.DescriptionMaxLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Range(
            ModelsValidationConstants.DiscountMinValue,
            ModelsValidationConstants.DiscountMaxValue,
            ErrorMessage = ErrorMessages.Models.DiscountRange)]
        public double DiscountPercentage { get; set; }

        [Required]
        [Range(ModelsValidationConstants.StockQuantityMinValue,
            ModelsValidationConstants.StockQuantityMaxValue,
            ErrorMessage = ErrorMessages.Models.StockQuantityMinLevel)]
        public int QuantityInStock { get; set; }


        [Required]
        [MinLength(
            ModelsValidationConstants.NamesMinLength,
            ErrorMessage = ErrorMessages.Models.NamesMinLength)]
        [MaxLength(
            ModelsValidationConstants.NamesMaxLength,
            ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
        public string CategoryName { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
    }
}
