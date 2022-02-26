using System.ComponentModel.DataAnnotations;

namespace JobsityChatProject.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
