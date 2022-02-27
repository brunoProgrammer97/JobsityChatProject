using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Infrastructure.DataBaseContext;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private JobsityChatContext _context;

        public UserRepository(JobsityChatContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserAsync(User user)
        {
            var userFinded = await _context.Users
                .Where(u => u.UserName.Equals(user.UserName) && u.PasswordHash.Equals(user.PasswordHash))
                .FirstOrDefaultAsync();

            return userFinded;
        }

        public async Task SaveUserAsync(User user)
        {
            _context.Set<User>().Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidadeUsedUserNameAsync(User user)
        {
            var userFinded = await _context.Users
                .Where(u => u.UserName.Equals(user.UserName))
                .FirstOrDefaultAsync();

            return userFinded == null;
        }
    }
}
