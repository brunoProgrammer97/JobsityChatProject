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
        private readonly IRabbitMqRepository _rabbitMqRepository;
        public StockBotServices(IStockSearchApiRepository stockSearchApiRepository,
            IRabbitMqRepository rabbitMqRepository)
        {
            _stockSearchApiRepository = stockSearchApiRepository;
            _rabbitMqRepository = rabbitMqRepository;
        }

        public async Task SendStock(string stockCode)
        {
            var stockPrice = await _stockSearchApiRepository.GetStockPrice(stockCode);

            var stockMessageBot = FormatStockBotQuoteMessage(stockCode, stockPrice);

            _rabbitMqRepository.InsertStockQuoteMessage(stockMessageBot);

            var teste = _rabbitMqRepository.GetStockQuoteMessage();
        }

        private string FormatStockBotQuoteMessage(string stockCode, string stockPrice)
        {
            return string.Format("“{0} quote is ${1} per share”",stockCode.ToUpper(), stockPrice);
        }
    }
}
