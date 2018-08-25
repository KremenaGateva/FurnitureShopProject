namespace WebStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }

        [Required]
        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Range(
            ModelsValidationConstants.MinAmount,
            ModelsValidationConstants.MaxAmount,
            ErrorMessage = ErrorMessages.Models.AmountRange)]
        public int Quantity { get; set; }
    }
}
