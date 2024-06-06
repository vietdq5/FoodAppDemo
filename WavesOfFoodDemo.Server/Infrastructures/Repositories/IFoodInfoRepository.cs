using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public interface IFoodInfoRepository : IGenericRepository<FoodInfo>
{
    Task<List<FoodInfoDto>> GetPopularFoods();
    Task<List<FoodInfo>> SearchFoodInfoDtosAsync(string foodName);
}