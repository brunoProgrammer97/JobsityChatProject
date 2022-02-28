using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Core.ServicesInterfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Hubs
{
    public class GeneralChatHub : Hub
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IStockBotServices _stockBotServices;
        public GeneralChatHub(IChatMessageRepository chatMessageRepository,
            IStockBotServices stockBotServices)
        {
            _chatMessageRepository = chatMessageRepository;
            _stockBotServices = stockBotServices;
        }
        public async Task SendMessage(string user, string message, string time)
        {
            var timestamp = DateTime.ParseExact(time, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            
            await _chatMessageRepository.SaveChatMessageAsync(new Models.ChatMessage()
                {
                    DateTime = timestamp,
                    Message = message,
                    User = user
                });

            
            message = String.Concat(message + "  ", "Timestamp: " + timestamp.ToString("F"));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendStockToBot(string message)
        {
            const string stockCommand = "/stock=";

            var hasStockCommand = message.Contains(stockCommand);

            if (hasStockCommand)
            {
                var stockInformation = message.Substring(message.IndexOf(stockCommand));
                if (stockInformation.Contains(' '))
                {
                    stockInformation = stockInformation.Substring(0, stockInformation.IndexOf(' '));
                }

                int positionStocCode = stockInformation.IndexOf("=");

                var stockCode = stockInformation.Substring(positionStocCode + 1);

                await _stockBotServices.SendStock(stockCode);
            }
        }
    }
}
