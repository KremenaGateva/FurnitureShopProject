namespace WebStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public int Id { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [Required]
        public User Buyer { get; set; }

        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
