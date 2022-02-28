using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IStockSearchApiRepository
    {
        Task<string> GetStockPrice(string stockCode);
    }
}
