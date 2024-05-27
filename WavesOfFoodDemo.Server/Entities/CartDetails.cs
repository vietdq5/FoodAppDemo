namespace WavesOfFoodDemo.Server.Entities
{
    public class CartDetails : BaseEntities
    {
        public Guid FoodId { get; set; }

        public FoodInfo FoodInfo { get; set; }

        public Guid CartId { get; set; }

        public CartInfo CartInfo { get; set; }
        public int Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
