﻿namespace CustomerBalancePlatform.Models
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ContactInformation ContactInformation { get; set; } = new();
        public decimal? CurrentBalance { get; set; }
    }
}
