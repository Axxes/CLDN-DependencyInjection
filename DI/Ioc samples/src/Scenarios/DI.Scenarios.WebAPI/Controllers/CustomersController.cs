using System.Collections.Generic;
using DI.Scenarios.WebAPI.Infra;
using DI.Scenarios.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Scenarios.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult Customer(int id)
        {
            var customer = _customerRepository.GetById(id);
            return Ok(customer);
        }
    }
}