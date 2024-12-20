﻿using CustomerBalancePlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomerBalancePlatform.Dtos
{
    public class SaveCustomerRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ContactInformation ContactInformation { get; set; } = new();
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Current Balance must be a non-negative value.")]
        public decimal? CurrentBalance { get; set; }
    }
}
