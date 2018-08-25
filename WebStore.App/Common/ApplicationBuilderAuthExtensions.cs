using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Models;
using WebStore.Utilities.Constants;

namespace WebStore.App.Common
{
    public static class ApplicationBuilderAuthExtensions
    { 

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(RolesConstants.RoleNames.Administrator),
            new IdentityRole(RolesConstants.RoleNames.DataOperator),
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                await CreateDefaultUserToRole(userManager, RolesConstants.DefaultUsernames.Administrator,
                    RolesConstants.Emails.Administrator, RolesConstants.DefaultPasswords.Administrator, RolesConstants.RoleNames.Administrator);
                await CreateDefaultUserToRole(userManager, RolesConstants.DefaultUsernames.DataOperator,
                   RolesConstants.Emails.DataOperator, RolesConstants.DefaultPasswords.DataOperator, RolesConstants.RoleNames.DataOperator);
                await CreateDefaultUserToRole(userManager, RolesConstants.DefaultUsernames.User,
                    RolesConstants.Emails.User, RolesConstants.DefaultPasswords.User, RolesConstants.RoleNames.User);
                
            }
        }

        private static async Task CreateDefaultUserToRole(UserManager<User> userManager,
            string username, string email, string defaultPassword, string roleName)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new User()
                {
                    UserName = username,
                    Email = email
                };

                await userManager.CreateAsync(user, defaultPassword);

                if (roleName != RolesConstants.RoleNames.User)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
