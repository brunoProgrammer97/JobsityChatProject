using JobsityChatProject.Core.Models;
using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Infrastructure.DataBaseContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private JobsityChatContext _context;

        public ChatMessageRepository(JobsityChatContext context)
        {
            _context = context;
        }

        public IEnumerable<ChatMessage> GetTopFiftyMessagesOrderedByTimestemp()
        {
            return _context.Messages.OrderByDescending(m => m.DateTime)
                .Take(50);
        }
    }
}
