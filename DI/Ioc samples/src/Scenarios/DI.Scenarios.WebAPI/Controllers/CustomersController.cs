using System;
using System.Collections.Generic;
using DI.Scenarios.WebAPI.Infra;
using DI.Scenarios.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DI.Scenarios.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerRepository _customerRepository1;

        public CustomersController(ICustomerRepository customerRepository, ICustomerRepository customerRepository1)
        {
            _customerRepository = customerRepository;
            _customerRepository1 = customerRepository1;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}/{id1}")]
        public ActionResult Customer(int id, int id1)
        {
            var customer0 = _customerRepository.GetById(id);
            var customer1 = _customerRepository1.GetById(id1);
            return Ok(new { customer0, customer1 });
        }
    }
}