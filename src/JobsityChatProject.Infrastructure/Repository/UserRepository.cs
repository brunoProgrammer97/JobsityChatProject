using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Infrastructure.DataBaseContext;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class ChatUserRepository : IChatUserRepository
    {
        private JobsityChatContext _context;

        public ChatUserRepository(JobsityChatContext context)
        {
            _context = context;
        }
        public async Task<ChatUser> GetUserAsync(ChatUser user)
        {
            var userFinded = await _context.Users
                .Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password))
                .FirstOrDefaultAsync();

            return userFinded;
        }

        public async Task SaveUserAsync(ChatUser user)
        {
            _context.Set<ChatUser>().Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidadeUsedUserNameAsync(ChatUser user)
        {
            var userFinded = await _context.Users
                .Where(u => u.UserName.Equals(user.UserName))
                .FirstOrDefaultAsync();

            return userFinded == null;
        }
    }
}
