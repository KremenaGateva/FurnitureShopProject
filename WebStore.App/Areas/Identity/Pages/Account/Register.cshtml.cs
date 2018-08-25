using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebStore.Models;
using WebStore.Utilities.Constants;
using WebStore.Utilities.Messages;

namespace WebStore.App.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
            [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
            public string Username { get; set; }

            [MinLength(
          ModelsValidationConstants.NamesMinLength,
          ErrorMessage = ErrorMessages.Models.NamesMinLength)]
            [MaxLength(
          ModelsValidationConstants.NamesMaxLength,
          ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
            [Display(Name = ModelsConstants.DisplayNamesConstants.FirstName)]
            public string FirstName { get; set; }

            [MinLength(
              ModelsValidationConstants.NamesMinLength,
              ErrorMessage = ErrorMessages.Models.NamesMinLength)]
            [MaxLength(
              ModelsValidationConstants.NamesMaxLength,
              ErrorMessage = ErrorMessages.Models.NamesMaxLength)]
            [Display(Name = ModelsConstants.DisplayNamesConstants.LastName)]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(
               ModelsValidationConstants.PasswordMaxLength,
                ErrorMessage = ErrorMessages.Models.PasswordLength,
                MinimumLength = ModelsValidationConstants.PasswordMinLength)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = ModelsConstants.DisplayNamesConstants.ConfirmPassword)]
            [Compare(
                nameof(Password), 
                ErrorMessage = ErrorMessages.Models.ConfirmPasswordMatchesPassword)]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };
                var result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
