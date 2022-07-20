using Microsoft.AspNetCore.Mvc;
using WebAppFirst.Models;
using WebAppFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppFirst.Controllers
{
    public class CustomersController : Controller
    {
        //List<Customer> listOfCutomers = new List<Customer>()
        //    {
        //        new Customer(){ Name = "SomeName1"},
        //        new Customer(){ Name = "SomeName2"},
        //        new Customer(){ Name = "SomeName3"},
        //    };
        //public IActionResult Index()
        //{ return View(listOfCutomers); }
        //public IActionResult View(int ID)
        //{ return View(listOfCutomers[ID]); }

        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult View(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}
