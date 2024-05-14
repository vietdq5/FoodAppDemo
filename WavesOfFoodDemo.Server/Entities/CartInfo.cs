﻿namespace WavesOfFoodDemo.Server.Entities
{
    public class CartInfo : BaseEntities
    {
        public string? Status { get; set; }

        public DateTime? DateOrder { get; set; }

        public Guid UserId { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}