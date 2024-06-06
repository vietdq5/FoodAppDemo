using WavesOfFoodDemo.Server.Dtos;

namespace WavesOfFoodDemo.Server.Services;

public interface IFoodInfoService
{
    Task<List<FoodInfoDto>> GetFoodInfoDtosAsync();
    Task<bool> AddFoodInfoAsync(FoodInfoCreateDto foodInfoCreateDto);
    Task<bool?> EditFoodInfoAsync(FoodInfoDto foodInfoDto);
    Task<bool?> RemoveFoodInfoDtosAsync(Guid id);
    Task<List<FoodInfoDto>> SearchFoodInfoDtosAsync(string foodName);
    Task<List<FoodInfoDto>> GetPopularFoods();
}
