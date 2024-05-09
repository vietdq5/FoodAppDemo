namespace WavesOfFoodDemo.Server.Dtos
{
    public class UserInfoCreateDto
    {
        public Guid Id { get; set; }

        public string? userName { get; set; }

        public decimal userPassword { get; set; }

        public string? userFullName { get; set; }

        public string? userAddress { get; set; }

        public string? userPhone { get; set; }
    }
}
