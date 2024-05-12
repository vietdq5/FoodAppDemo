﻿namespace WavesOfFoodDemo.Server.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string UserPassword { get; set; }

        public string? UserFullName { get; set; }

        public string? UserAddress { get; set; }

        public string? UserPhone { get; set; }
    }
}
