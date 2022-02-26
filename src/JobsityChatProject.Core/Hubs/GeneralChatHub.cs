using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Hubs
{
    public class GeneralChatHub : Hub
    {
        public async Task SendMessage(string usuario, string mensagem)
        {
            await Clients.All.SendAsync("ReceiveMessage", usuario, mensagem);
        }
    }
}
