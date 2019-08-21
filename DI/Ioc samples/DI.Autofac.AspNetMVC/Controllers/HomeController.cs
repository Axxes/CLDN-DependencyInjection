using DI.Autofac.AspNetMVC.Infra;
using DI.Autofac.AspNetMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DI.Autofac.AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            IEnumerable<Customer> customers = _CustomerRepository.GetAll();
            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            Customer customer = _CustomerRepository.GetById(id);
            return View(customer);
        }
    }
}