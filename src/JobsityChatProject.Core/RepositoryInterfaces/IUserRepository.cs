using JobsityChatProject.Core.Models;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task SaveUserAsync(User user);
        Task<User> GetUserAsync(User user);

        Task<bool> ValidadeUsedUserNameAsync(User user);
    }
}
