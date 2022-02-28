using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Core.ServicesInterfaces;
using System.Collections.Generic;

namespace JobsityChatProject.Core.Services
{
    public class ChatMessageServices : IChatMessageServices
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        public ChatMessageServices(IChatMessageRepository chatMessageRepository)
        {
            _chatMessageRepository = chatMessageRepository;
        }
        public IEnumerable<ChatMessage> GetChatMessages()
        {
            return _chatMessageRepository.GetTopFiftyMessagesOrderedByTimestemp();
        }
    }
}
