using Microsoft.EntityFrameworkCore;
using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public class FoodInfoRepository : GenericRepository<FoodInfo>, IFoodInfoRepository
{
    public FoodInfoRepository(FoodDbContext foodDbContext) : base(foodDbContext)
    {
    }

    public async Task<List<FoodInfo>> SearchFoodInfoDtosAsync(string foodName)
    {
        var query = _foodDbContext.FoodInfos.AsQueryable();
        query = query.Where(s => s.Name.Contains(foodName));
        return await query.AsNoTracking().ToListAsync();
    }
}