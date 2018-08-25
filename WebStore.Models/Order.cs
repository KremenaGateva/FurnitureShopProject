namespace WebStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebStore.Utilities.Constants;

    public class Order
    {
        public Order()
        {
            this.Products = new List<OrderProduct>();
        }

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = ModelsConstants.PriceColumnType)]
        public decimal Price { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public User Creator { get; set; }

        public ICollection<OrderProduct> Products { get; set; }
    }
}
