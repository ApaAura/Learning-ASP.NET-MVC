using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebAppFirst.Data;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers.Api
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET/api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //GET/api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(notFoundResponse);
            }
            else
            {
                return customer;
            }
        }
        //POST/api/customers
        [System.Web.Http.HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return customer;
            }
        }
        //PUT/api/customers/1
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb=_context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb==null)
            {
                var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(notFoundResponse);
            }
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeID = customer.MembershipTypeID;
            _context.SaveChanges();
        }
        //DELETE/api/customers/1
        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb=_context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
            {
                var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(notFoundResponse);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
    }
}
