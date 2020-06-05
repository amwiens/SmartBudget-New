using SmartBudget.Domain.Models;

using System.Threading.Tasks;

namespace SmartBudget.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}