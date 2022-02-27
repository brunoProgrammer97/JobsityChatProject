using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using System.Threading.Tasks;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task GetUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
