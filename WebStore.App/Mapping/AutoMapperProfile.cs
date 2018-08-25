namespace WebStore.App.Mapping
{
    using System;
    using AutoMapper;
    using WebStore.Common.Admin.ViewModels;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Common.DataOperator.BindingModels;
    using WebStore.Common.DataOperator.ViewModels;
    using WebStore.Common.UserCommon.ViewModels;
    using WebStore.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Product, ProductConciseViewModel>();
            this.CreateMap<ProductBindingModel, Product>();

            this.CreateMap<Product, ProductBindingModel>()
                .ForMember(pb => pb.CategoryName,
                opt => opt.MapFrom(p => p.Category.Name));

            this.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(pd => pd.CategoryName,
                       opt => opt.MapFrom(p => p.Category.Name));

            this.CreateMap<Category, CategoryConciseViewModel>()
                .ForMember(cc => cc.ProductsCount,
                opt => opt.MapFrom(c => c.Products.Count));

            this.CreateMap<Category, CategoryDetailsViewModel>();
            this.CreateMap<Product, CategoryProductViewModel>();

            this.CreateMap<Product, ProductIndexConciseViewModel>()
                .ForMember(pc => pc.ShortDescription,
                opt => opt.MapFrom(p => p.Description.Substring(0, Math.Min(20, p.Description.Length)) + "..."))
                .ForMember(pc => pc.SellPrice,
                opt => opt.MapFrom(p => p.Price - (p.Price * ((decimal)p.DiscountPercentage/100m))));

            this.CreateMap<Category, CategoryIndexConciseViewModel>();

            this.CreateMap<Category, CategoryIndexDetailsViewModel>()
                .ForMember(vm => vm.ProductsCount,
                opt => opt.MapFrom(c => c.Products.Count));

            this.CreateMap<Product, ProductIndexDetailsViewModel>()
                .ForMember(vm => vm.SellPrice,
                opt => opt.MapFrom(p => p.Price - (p.Price * ((decimal)p.DiscountPercentage / 100m))))
                .ForMember(vm => vm.CategoryName,
                opt => opt.MapFrom(p => p.Category.Name));

            this.CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>()
                .ForMember(vm => vm.ItemName,
                opt => opt.MapFrom(i => i.Product.Name))
                .ForMember(vm => vm.Price,
                opt => opt.MapFrom(i => i.Product.Price))
                .ForMember(vm => vm.ImagePath,
                opt => opt.MapFrom(i => i.Product.ImagePath));

            this.CreateMap<ShoppingCart, ShoppingCartViewModel>();

            this.CreateMap<Order, OrderConciseViewModel>()
                .ForMember(vm => vm.ProductsCount,
                opt => opt.MapFrom(o => o.Products.Count));

            this.CreateMap<Order, OrderDetailsViewModel>();

            this.CreateMap<OrderProduct, OrderProductsDetailsViewModel>()
                .ForMember(vm => vm.ProductName,
                opt => opt.MapFrom(op => op.Product.Name))
                .ForMember(vm => vm.Price,
                opt => opt.MapFrom(op => op.Product.Price))
                .ForMember(vm => vm.Quantity,
                opt => opt.MapFrom(op => op.ProductQuantity));

            this.CreateMap<User, UserConciseViewModel>()
                .ForMember(vm => vm.IsAdmin,
                opt => opt.Ignore())
                .ForMember(vm => vm.IsDataOperator,
                opt => opt.Ignore());

            this.CreateMap<User, UserDetailsViewModel>()
                .ForMember(vm => vm.Roles,
                opt => opt.Ignore())
                 .ForMember(vm => vm.FullName,
                opt => opt.MapFrom(u => u.FirstName + " " + u.LastName));

            this.CreateMap<Order, OrderConciseAdminViewModel>()
                .ForMember(vm => vm.ProductsCount,
               opt => opt.MapFrom(o => o.Products.Count));
        }
    }
}
