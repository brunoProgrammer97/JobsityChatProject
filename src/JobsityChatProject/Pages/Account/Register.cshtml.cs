using JobsityChatProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace JobsityChatProject.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegisterViewModel UserRegisterViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                    return Redirect("Account/Home");
            }

            return Redirect("Index");
        }
    }
}
