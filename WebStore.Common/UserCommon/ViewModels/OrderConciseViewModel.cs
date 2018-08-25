namespace WebStore.Common.UserCommon.ViewModels
{
    using System;

    public class OrderConciseViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }

        public int ProductsCount { get; set; }

        public string Status { get; set; }
    }
}
