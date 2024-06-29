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

    public async Task<List<FoodInfo>> GetPopularFoods()
    {
        var query = _foodDbContext.CartDetails.AsQueryable();
        var queryGroup = query.GroupBy(s => s.FoodId);
        var newQuery = queryGroup
            .Select(s => new
            {
                FoodId = s.Key,
                FoodInfoAfterGroup = s.First().FoodInfo,
                SumQuantity = s.Sum(t => t.Quantity)
            })
            .OrderByDescending(s => s.SumQuantity)
            .Take(4);
        var dataGroup = await newQuery.ToListAsync();
        return dataGroup.Select(s => s.FoodInfoAfterGroup).ToList();
    }
}