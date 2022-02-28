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
            var timestamp = DateTime.Now;
            message = String.Concat("  " + message + "  Timestamp: ", timestamp.ToString("F"));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
