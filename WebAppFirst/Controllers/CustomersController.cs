using Microsoft.AspNetCore.Mvc;
using WebAppFirst.Models;
using WebAppFirst.Data;
using Microsoft.EntityFrameworkCore;
using WebAppFirst.ViewModels;
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
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType=membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customer.MembershipTypeID = customer.MembershipTypeID;
                customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}
