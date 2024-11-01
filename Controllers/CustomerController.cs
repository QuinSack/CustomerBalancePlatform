﻿using CustomerBalancePlatform.Models;
using CustomerBalancePlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBalancePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetCustomersAsync().Result;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(string id)
        {
            var result = _customerService.GetCustomerByIdAsync(id).Result;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            var result = _customerService.AddCustomerAsync(customer).Result;
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCustomerDetails(string id, Customer updatedCustomer)
        {
            var result = _customerService.UpdateCustomerAsync(id, updatedCustomer).Result;
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(string id)
        {
            var result = _customerService.DeleteCustomerAsync(id).Result;
            return Ok(result);
        }
    }
}