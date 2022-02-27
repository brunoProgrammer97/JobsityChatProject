using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.ServicesInterfaces;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace JobsityChatProject.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserLoginViewModel UserLoginViewModel { get; set; }
        private IChatUserServices _chatUserResvices;
        public IndexModel(IChatUserServices chatUserResvices)
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
                    var userRegistered = await _chatUserResvices.GetUserAsync(user);

                    if (userRegistered != null)
                    {
                        await _chatUserResvices.SignInUserAsync(user, HttpContext);
                        return Redirect("~/Account/Home");
                    }                    
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
                UserName = UserLoginViewModel.UserName,
                Password = UserLoginViewModel.Password
            };
        }
    }
}
