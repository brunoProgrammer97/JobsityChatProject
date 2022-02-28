using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Infrastructure.DataBaseContext;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using JobsityChatProject.Infrastructure.Queries;

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
            var findedUser = await _context.Users
                .Where(UserQueries.GetUserByPasswordAndUsername(user.UserName, user.Password))
                .FirstOrDefaultAsync();

            return findedUser;
        }

        public async Task SaveUserAsync(ChatUser user)
        {
            _context.Set<ChatUser>().Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidadeUsedUserNameAsync(ChatUser user)
        {
            var findedUser = await _context.Users
                .Where(UserQueries.GetByUsername(user.UserName))
                .FirstOrDefaultAsync();

            return findedUser != null;
        }
    }
}
