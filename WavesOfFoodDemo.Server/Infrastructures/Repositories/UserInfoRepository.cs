using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
{
    public UserInfoRepository(FoodDbContext foodDbContext) : base(foodDbContext)
    {
    }
}
