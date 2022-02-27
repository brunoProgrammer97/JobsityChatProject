using JobsityChatProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.ServicesInterfaces
{
    public interface IChatMessageServices
    {
        IEnumerable<ChatMessage> GetChatMessages();
    }
}
