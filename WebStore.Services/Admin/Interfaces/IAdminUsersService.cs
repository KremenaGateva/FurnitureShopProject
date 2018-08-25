namespace WebStore.Services.Admin.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.Admin.BindingModels;
    using WebStore.Common.Admin.ViewModels;

    public interface IAdminUsersService
    {
        Task<IEnumerable<UserConciseViewModel>> GetUsersAsync();

        Task<bool> AddToRoleDataOperatorAsync(string id);

        Task<bool> ChangePasswordAsync(ResetPasswordBindingModel model);

        Task<bool> BanUserAsync(string id);

        Task<UserDetailsViewModel> GetUserModelById(string id);

        bool CheckIfAuthorized(string id);

    }
}
