using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IStockSearchApiRepository
    {
        Task<string> GetStockPrice(string stockCode);
    }
}
