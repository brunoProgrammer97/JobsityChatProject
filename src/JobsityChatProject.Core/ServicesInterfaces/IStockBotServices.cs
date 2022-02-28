using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.ServicesInterfaces
{
    public interface IStockBotServices
    {
        Task SendStock(string stockCode);
    }
}
