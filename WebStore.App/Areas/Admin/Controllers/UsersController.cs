namespace WebStore.App.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.App.Extensions;
    using WebStore.App.Helpers.Messages;
    using WebStore.Common.Admin.BindingModels;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class UsersController : AdminController
    {
        private readonly IAdminUsersService usersService;

        public UsersController(IAdminUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> MakeDataOperator(string id)
        {
            if (id == null)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Danger

                });
                return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });

            }
            if (!await this.usersService.AddToRoleDataOperatorAsync(id))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToAddUserToRole,
                    Type = MessageType.Info

                });
                return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });

            }

            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.AddedUserToRole,
                Type = MessageType.Success

            });

            return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });
        }

        [HttpGet]
        public IActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Danger

                });
                return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });
            }
            var model = new ResetPasswordBindingModel() { Id = id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = ErrorMessages.Models.InvalidModelStateMessage,
                    Type = MessageType.Danger

                });
                return View(model);
            }
            if (!await this.usersService.ChangePasswordAsync(model))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToChangeUserPassword,
                    Type = MessageType.Warning

                });
                return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });

            }
            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.ChangedUserPassword,
                Type = MessageType.Success

            });
            return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });
        }

        public async Task<IActionResult> Ban(string id)
        {
            if (!await this.usersService.BanUserAsync(id))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToBanUser,
                    Type = MessageType.Warning

                });
                return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });

            }
            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.BanUser,
                Type = MessageType.Success

            });
            return RedirectToPage("/Users/All", new { area = AreasConstants.AreaNames.Administrator });
        }
    }
}
