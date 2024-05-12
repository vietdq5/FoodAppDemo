using System;

namespace WavesOfFoodDemo.Server.Dtos;

public class FoodInfoDto : FoodInfoCreateDto
{
    public Guid Id { get; set; }
}