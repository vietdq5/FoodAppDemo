﻿using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server.Infrastructures;

public interface IFoodInfoRepository : IGenericRepository<FoodInfo>
{
    Task<List<FoodInfo>> SearchFoodInfoDtosAsync(string foodName);
}