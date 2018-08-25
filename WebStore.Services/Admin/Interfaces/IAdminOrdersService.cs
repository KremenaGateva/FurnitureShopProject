namespace WebStore.Services.Admin.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.Admin.ViewModels;

    public interface IAdminOrdersService
    {
        Task<ICollection<OrderConciseAdminViewModel>> GetOrdersAsync();
        Task<bool> ConfirmOrderAsync(int id);

    }
}
