using JobsityChatProject.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.ServicesInterfaces
{
    public interface IChatUserServices
    {
        Task<bool> UsernameAlreadyUsed(ChatUser user);
        Task<ChatUser> GetUserAsync(ChatUser user);
        Task SaveUserAsync(ChatUser user);
        Task SignInUserAsync(ChatUser user, HttpContext context);
        Task SignOutUserAsync(HttpContext context);
    }
}
