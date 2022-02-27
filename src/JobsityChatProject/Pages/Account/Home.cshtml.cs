using JobsityChatProject.Core.ServicesInterfaces;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace JobsityChatProject.Pages.Account
{
    [Authorize]
    public class HomeModel : PageModel
    {
        public UserChatViewModel UserChatViewModel { get; set; }
        private IChatUserServices _chatUserServices { get; set; }
        public HomeModel(IChatUserServices chatUserServices)
        {
            _chatUserServices = chatUserServices;
        }
        public void OnGet()
        {
            UserChatViewModel = new UserChatViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _chatUserServices.SignOutUserAsync(HttpContext);
            return Redirect("~/Index");
        }
    }
}
