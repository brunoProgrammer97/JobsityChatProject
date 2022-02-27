using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Services
{
    public class ChatUserServices : IChatUserServices
    {
        private readonly IChatUserRepository _userRepository;
        public ChatUserServices(IChatUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ChatUser> GetUserAsync(ChatUser user)
        {
            return await _userRepository.GetUserAsync(user);
        }

        public async Task SaveUserAsync(ChatUser user)
        {
            await _userRepository.SaveUserAsync(user);
        }

        public async Task SignInUserAsync(ChatUser user, HttpContext context)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties();

            await
                context
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        }

    }
}

