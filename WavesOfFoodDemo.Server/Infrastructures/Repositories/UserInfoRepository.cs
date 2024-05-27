using Microsoft.EntityFrameworkCore;
using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public class UserInfoRepository : GenericRepository<UserInfo>,IUserInfoRepository
{
    public UserInfoRepository(FoodDbContext foodDbContext) : base(foodDbContext)
    {
    }
    public async Task<List<UserInfo>> SearchUserInfoDtosAsync(string userName)
    {
        var query = _foodDbContext.UserInfos.AsQueryable();
        query = query.Where(s => s.UserName.Contains(userName));
        return await query.AsNoTracking().ToListAsync();
    }
}
