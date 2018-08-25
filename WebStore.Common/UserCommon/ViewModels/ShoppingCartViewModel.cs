namespace WebStore.Common.UserCommon.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartViewModel
    {
        public int Id { get; set; }

        public ICollection<ShoppingCartItemViewModel> Items { get; set; }

        public decimal TotalOrderPrice
        {
            get
            {
                return this.Items.Sum(i => i.TotalPrice);
            }
        }
    }
}
