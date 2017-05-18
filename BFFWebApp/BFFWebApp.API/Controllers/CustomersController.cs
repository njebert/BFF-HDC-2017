using AutoMapper;
using BFFLogic;
using BFFWebApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFFWebApp.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerAccessor _customerAccessor;
        public CustomersController(ICustomerAccessor customerAccessor)
        {
            _customerAccessor = customerAccessor;
        }
        [HttpGet("GetCustomerCount")]
        public int GetCustomerCount()
        {
            return 10;
        }

        public List<Customer> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BFFLogic.Models.Customers, Customer>());
            return Mapper.Map<List<BFFLogic.Models.Customers>, List<Customer>>(_customerAccessor.GetCustomers());
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(long id)
        {
            return new ObjectResult(null);
        }
    }
}