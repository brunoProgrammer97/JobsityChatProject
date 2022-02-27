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
                    await _chatUserResvices.SaveUserAsync(user);
                    await _chatUserResvices.SignInUserAsync(user, HttpContext);

                    return Redirect("Account/Home");
                }

                return Redirect("Index");
            }
            catch (Exception)
            {
                return Redirect("Index");
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
