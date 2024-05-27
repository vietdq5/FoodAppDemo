using Microsoft.EntityFrameworkCore;
using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public class CartInfoRepository : GenericRepository<CartInfo>, ICartInfoRepository
{
    public CartInfoRepository(FoodDbContext foodDbContext) : base(foodDbContext)
    {
    }

    public async Task<IEnumerable<CartHistoryDto>> GetTransactions(Guid userId)
    {
        var query = _foodDbContext.CartInfos
            .Where(item => item.UserId == userId)
            .AsNoTracking()
            .AsQueryable();
        //foreach (var cartInfo in query)
        //{
        //    var newObject = new CartHistoryDto();
        //    newObject.Status = cartInfo.Status;
        //}
        var result = query.Select(item => new CartHistoryDto()
        {
            Status = item.Status,
            DateOrder = item.DateOrder,
            TotalPrice = item.CartDetails.Sum(s => s.Quantity * s.FoodInfo.Price),
            CartDetails = item.CartDetails.Select(cd => new CartdetailHistoryDto()
            {
               Image = cd.FoodInfo.ImageMenu,
               FoodName = cd.FoodInfo.Name,
               Quantity = cd.Quantity,
               Price = cd.FoodInfo.Price,
            })
        });
        return await result.ToListAsync();
    }
}