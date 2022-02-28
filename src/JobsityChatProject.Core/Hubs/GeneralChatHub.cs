using JobsityChatProject.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Hubs
{
    public class GeneralChatHub : Hub
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        public GeneralChatHub(IChatMessageRepository chatMessageRepository)
        {
            _chatMessageRepository = chatMessageRepository;
        }
        public async Task SendMessage(string user, string message)
        {
            await SaveMessageOnDatabase(user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        private async Task SaveMessageOnDatabase(string user, string message)
        {
            await _chatMessageRepository.SaveChatMessageAsync(new Models.ChatMessage()
            {
                DateTime = DateTime.Now,
                Message = message,
                User = user
            });
        }
    }
}
