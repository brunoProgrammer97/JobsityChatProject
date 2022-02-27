using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobsityChatProject.Pages.Account
{
    public class HomeModel : PageModel
    {
        public UserChatViewModel UserChatViewModel { get; set; }
        public void OnGet()
        {
            UserChatViewModel = new UserChatViewModel();
        }
    }
}
