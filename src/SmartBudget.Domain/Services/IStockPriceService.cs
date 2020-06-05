using System.Threading.Tasks;

namespace SmartBudget.Domain.Services
{
    public interface IStockPriceService
    {
        Task<double> GetPrice(string symbol);
    }
}