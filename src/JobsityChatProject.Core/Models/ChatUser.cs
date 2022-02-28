using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobsityChatProject.Core.Models
{
    public class ChatUser
    {
        [Required]
        [Key]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RepeatedPassword { get; set; }
    }
}
