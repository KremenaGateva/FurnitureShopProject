using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Common.UserCommon.ViewModels;

namespace WebStore.Services.User.Interfaces
{
    public interface IUserOrdersService
    {
        Task<bool> MakeOrderAsync(int id);

        IEnumerable<OrderConciseViewModel> GetAllOrdersForCurrentUser();

        Task<OrderDetailsViewModel> GetOrderByIdAsync(int id);
    }
}
