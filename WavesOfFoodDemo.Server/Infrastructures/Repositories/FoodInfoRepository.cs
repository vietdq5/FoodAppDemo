using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public class FoodInfoRepository : GenericRepository<FoodInfo>, IFoodInfoRepository
{
    public FoodInfoRepository(FoodDbContext foodDbContext) : base(foodDbContext)
    {
    }
}