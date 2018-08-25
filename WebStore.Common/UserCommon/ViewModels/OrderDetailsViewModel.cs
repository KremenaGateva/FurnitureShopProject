namespace WebStore.Common.UserCommon.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderProductsDetailsViewModel> Products { get; set; }
    }
}
