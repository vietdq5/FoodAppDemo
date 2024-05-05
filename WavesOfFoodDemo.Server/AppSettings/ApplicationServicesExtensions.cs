﻿using Microsoft.Extensions.DependencyInjection;
using WavesOfFoodDemo.Server.Infrastructures;
using WavesOfFoodDemo.Server.Services;

namespace WavesOfFoodDemo.Server.AppSettings;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServicesExtension(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IFoodInfoRepository, FoodInfoRepository>();
        services.AddTransient<IFoodInfoService, FoodInfoService>();
    }
}
