using JobsityChatProject.Core.Models;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IChatUserRepository
    {
        Task SaveUserAsync(ChatUser user);
        Task<ChatUser> GetUserAsync(ChatUser user);

        Task<bool> ValidadeUsedUserNameAsync(ChatUser user);
    }
}
