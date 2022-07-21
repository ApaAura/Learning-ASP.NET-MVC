using Microsoft.AspNetCore.Mvc;
using WebAppFirst.Models;
using WebAppFirst.ViewModels;
using WebAppFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppFirst.Controllers
{
    public class MoviesController : Controller
    {
        //public IActionResult Random()
        //{
        //    var movie = new Movie() { Name = "!aruA" };
        //    var customers = new List<Customer>()
        //    {
        //        new Customer() { Name ="Customer 1"},
        //        new Customer() { Name ="Customer 2"}
        //    };
        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
            // ViewData["Movie"]= movie;
            //return Content("Hello World !");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page= 1, SortBy="name"});
        //}
        //List<Movie> listOfMovies = new List<Movie>()
        //{
        //    new Movie() {Name ="Movie 1"},
        //    new Movie() {Name ="Movie 2"},
        //    new Movie() {Name ="Movie 3"},
        //    new Movie() {Name ="Movie 4"},
        //};
        //[Route("Movies/released/{{year}}/{{month:regex(\\d{2}):range(1,12)}}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{ return Content(year + "/" + month); }
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
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre= genre
            };
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.Added = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.Released = movie.Released;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return NotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movies,
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult MovieFormViewModel(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie==null)
            {
                return NotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie
            };
            return View("MovieForm",viewModel);
        }
    }
}
