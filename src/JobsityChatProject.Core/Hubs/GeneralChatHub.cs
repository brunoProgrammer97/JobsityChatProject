using JobsityChatProject.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Hubs
{
    public class GeneralChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var timestamp = DateTime.Now;
            message = String.Concat("  " + message + "  Timestamp: ", timestamp.ToString("F"));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
