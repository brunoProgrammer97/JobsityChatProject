using JobsityChatProject.Core.Models;
using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace JobsityChatProject.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserRegisterViewModel UserRegisterViewModel { get; set; }
        public IndexModel()
        {

        }

        public void OnGet()
        {

        }
    }
}
