namespace WavesOfFoodDemo.Server.Dtos;

public class FoodInfoCreateDto
{
    public string? Name { get; set; }

    public decimal Price { get; set; }

    public string? ImageMenu { get; set; }

    public string? ImageDetail { get; set; }

    public string? Description { get; set; }

    public string? Ingredient { get; set; }
}