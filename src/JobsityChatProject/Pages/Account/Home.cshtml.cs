using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobsityChatProject.Pages.Account
{
    [Authorize]
    public class HomeModel : PageModel
    {
        public UserChatViewModel UserChatViewModel { get; set; }
        public void OnGet()
        {
            UserChatViewModel = new UserChatViewModel();
        }
    }
}
