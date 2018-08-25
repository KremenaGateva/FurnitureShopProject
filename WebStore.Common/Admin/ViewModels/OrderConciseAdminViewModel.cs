namespace WebStore.Common.Admin.ViewModels
{
    using System;

    public class OrderConciseAdminViewModel
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int ProductsCount { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }
    }
}
