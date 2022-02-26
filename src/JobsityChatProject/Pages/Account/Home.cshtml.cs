using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobsityChatProject.Pages.Account
{
    public class HomeModel : PageModel
    {
        public UserChatViewModel UserChatViewModel { get; set; }
        public void OnGet()
        {
            UserChatViewModel = new UserChatViewModel();
            this.UserChatViewModel.Username = "Teste";
        }
    }
}
