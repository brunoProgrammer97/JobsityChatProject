using JobsityChatProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IChatMessageRepository
    {
        IEnumerable<ChatMessage> GetTopFiftyMessagesOrderedByTimestemp();

        Task SaveChatMessageAsync(ChatMessage message);
    }
}
