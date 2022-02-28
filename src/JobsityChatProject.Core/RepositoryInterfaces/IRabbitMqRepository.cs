using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IRabbitMqRepository
    {
        void InsertStockQuoteMessage(string stockQuote);
        string GetStockQuoteMessage();
    }
}
