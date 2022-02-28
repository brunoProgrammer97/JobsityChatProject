using JobsityChatProject.Core.RepositoryInterfaces;
using JobsityChatProject.Core.ServicesInterfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.Services
{
    public class StockBotServices : IStockBotServices
    {
        private readonly IStockSearchApiRepository _stockSearchApiRepository;

        public StockBotServices(IStockSearchApiRepository stockSearchApiRepository)
        {
            _stockSearchApiRepository = stockSearchApiRepository;
        }

        public async Task SendStock(string stockCode)
        {
            var stockPrice = await _stockSearchApiRepository.GetStockPrice(stockCode);

            var stockMessageBot = FormatStockBotQuoteMessage(stockCode, stockPrice);
        }

        private string FormatStockBotQuoteMessage(string stockCode, string stockPrice)
        {
            return string.Format("“{0} quote is ${1} per share”",stockCode.ToUpper(), stockPrice);
        }
    }
}
