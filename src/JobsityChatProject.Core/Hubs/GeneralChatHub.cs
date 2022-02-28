﻿using JobsityChatProject.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Globalization;
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
        public async Task SendMessage(string user, string message, string time)
        {
            var timestamp = DateTime.ParseExact(time, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            message = String.Concat(message + "  ", "Timestamp: " + timestamp.ToString("F"));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SaveMessage(string user, string message, string time)
        {
            var timestamp = DateTime.ParseExact(time, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            await _chatMessageRepository
                .SaveChatMessageAsync(  new Models
                .ChatMessage()
                { 
                    DateTime = timestamp,
                    Message = message,
                    User = user
                });
        }
    }
}
