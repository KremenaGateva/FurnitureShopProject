using System.ComponentModel.DataAnnotations;
using WebStore.Utilities.Constants;
using WebStore.Utilities.Messages;

namespace WebStore.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; }

        public int OrderId { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        [Range(
            ModelsValidationConstants.MinAmount,
            ModelsValidationConstants.MaxAmount,
            ErrorMessage = ErrorMessages.Models.AmountRange)]
        public int ProductQuantity { get; set; }
    }
}
