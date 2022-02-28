using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.ServicesInterfaces;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobsityChatProject.Pages.Account
{
    [Authorize]
    public class HomeModel : PageModel
    {
        public UserChatViewModel UserChatViewModel { get; set; }
        public IEnumerable<ChatMessage> ChatMessages { get; set; }
        private IChatUserServices _chatUserServices { get; set; }
        private IChatMessageServices _chatMessageServices { get; set; }
        public HomeModel(IChatUserServices chatUserServices, IChatMessageServices chatMessageServices)
        {
            _chatUserServices = chatUserServices;
            _chatMessageServices = chatMessageServices;
        }
        public void OnGet()
        {
            var claimUsername = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            this.ChatMessages = _chatMessageServices.GetChatMessages();
            UserChatViewModel = new UserChatViewModel();
            UserChatViewModel.Username = claimUsername.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _chatUserServices.SignOutUserAsync(HttpContext);
            return Redirect("~/Index");
        }
    }
}
