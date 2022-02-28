using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.ServicesInterfaces;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace JobsityChatProject.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegisterViewModel UserRegisterViewModel { get; set; }
        private IChatUserServices _chatUserResvices;
        public RegisterModel(IChatUserServices chatUserResvices)
        {
            _chatUserResvices = chatUserResvices;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = GetChatUserFromViewModel();

                    if (await _chatUserResvices.UsernameAlreadyUsed(user))
                    {
                        ModelState.AddModelError("username", "username already used!");
                        return Page();
                    }

                    if ((user.Password != user.RepeatedPassword) || user.Password == null)
                    {
                        ModelState.AddModelError("userpassword", "check password and please insert de same password in both fields!");
                        return Page();
                    }

                    await _chatUserResvices.SaveUserAsync(user);
                    await _chatUserResvices.SignInUserAsync(user, HttpContext);

                    return Redirect("~/Account/Home");
                }

                return Redirect("~/Index");
            }
            catch (Exception)
            {
                return Redirect("~/Index");
            }
        }

        private ChatUser GetChatUserFromViewModel()
        {
            return new ChatUser()
            {
                UserName = UserRegisterViewModel.UserName,
                Password = UserRegisterViewModel.Password,
                RepeatedPassword = UserRegisterViewModel.RepeatedPassword
            };
        }
    }
}
