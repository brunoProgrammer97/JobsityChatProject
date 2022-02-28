using JobsityChatProject.Core.RepositoryInterfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class StockSearchApiRepository : IStockSearchApiRepository
    {
        public async Task<string> GetStockPrice(string stockCode)
        {

            HttpResponseMessage response;

            using (var handler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var urlApi = "https://stooq.com/q/l/?s=" + stockCode + "&f=sd2t2ohlcv&h&e=csv";

                    response = await client.GetAsync(urlApi);

                }
            }

            string[] splitedStockData = response.Content.ReadAsStringAsync().Result.Split(",");
            return splitedStockData[splitedStockData.Length - 2];
        }
    }
}
