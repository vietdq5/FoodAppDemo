using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public interface ICartInfoRepository : IGenericRepository<CartInfo>
{
    Task<IEnumerable<CartHistoryDto>> GetTransactions(Guid userId);
}
