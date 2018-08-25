namespace WebStore.Services.User.Interfaces
{
    using System.Threading.Tasks;
    using WebStore.Common.UserCommon.ViewModels;

    public interface IUserShoppingCartService
    {
        Task<bool> AddItemToCartAsync(int productId);

        Task<ShoppingCartViewModel> GetShoppingCartViewModelAsync();

        Task<bool> RemoveItemAsync(int id);
    }
}
