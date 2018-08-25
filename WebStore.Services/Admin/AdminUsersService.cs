namespace WebStore.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.Admin.BindingModels;
    using WebStore.Common.Admin.ViewModels;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;

    public class AdminUsersService : BaseService, IAdminUsersService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AdminUsersService(
            WebStoreContext context,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager) 
            : base(context, mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        public async Task<IEnumerable<UserConciseViewModel>> GetUsersAsync()
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            var users = this.Context.Users
                .Where(u => u.Id != currentUserId)
                .ToList();

            var models = this.Mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            foreach (var model in models)
            {
                var user = await this.userManager.FindByNameAsync(model.Username);
                var roles = await this.userManager.GetRolesAsync(user);
                model.IsDataOperator = roles.Contains(RolesConstants.RoleNames.DataOperator);
                model.IsAdmin = roles.Contains(RolesConstants.RoleNames.Administrator);
            }

            return models;
        }

        public async Task<bool> AddToRoleDataOperatorAsync(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.AddToRoleAsync(user, RolesConstants.RoleNames.DataOperator);
            return true;
        }

        public async Task<bool> ChangePasswordAsync(ResetPasswordBindingModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.Id);
            var removePassword = await this.userManager.RemovePasswordAsync(user);
            if (removePassword.Succeeded)
            {
                //Removed Password Success
                var AddPassword = await this.userManager.AddPasswordAsync(user, model.NewPassword);
                if (AddPassword.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> BanUserAsync(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.SetLockoutEnabledAsync(user, true);
            await this.userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset(new DateTime(2060, 01, 01)));

            return true;
        }

        public async Task<UserDetailsViewModel> GetUserModelById(string id)
        {
            var user = await this.Context.Users.FindAsync(id);

            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.Mapper.Map<UserDetailsViewModel>(user);
            model.Roles = roles;

            return model;
        }

        public bool CheckIfAuthorized(string id)
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            if (currentUserId == id)
            {
                return false;
            }

            return true;
        }

      
    }
}
