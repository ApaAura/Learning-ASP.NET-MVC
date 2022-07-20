using Microsoft.AspNetCore.Mvc;
using WebAppFirst.Models;
using WebAppFirst.ViewModels;
using WebAppFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppFirst.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "!aruA" };
            var customers = new List<Customer>()
            {
                new Customer() { Name ="Customer 1"},
                new Customer() { Name ="Customer 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            // ViewData["Movie"]= movie;
            //return Content("Hello World !");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page= 1, SortBy="name"});
        }
        public ActionResult Edit(int id)
        { return Content("id=" + id);}
        List<Movie> listOfMovies = new List<Movie>()
        {
            new Movie() {Name ="Movie 1"},
            new Movie() {Name ="Movie 2"},
            new Movie() {Name ="Movie 3"},
            new Movie() {Name ="Movie 4"},
        };
        [Route("Movies/released/{{year}}/{{month:regex(\\d{2}):range(1,12)}}")]
        public ActionResult ByReleaseDate(int year, int month)
        { return Content(year + "/" + month); }
        //public IActionResult Index()
        //{ return View(listOfMovies); }
        //public IActionResult View(int ID)
        //{ return View(listOfMovies[ID]);}
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies=_context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult View(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }
    }
}
