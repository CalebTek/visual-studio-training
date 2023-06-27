using Microsoft.AspNetCore.Mvc;
using Mvc_empty.Models;

namespace Mvc_empty.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MovieController(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult MovieList()
        {
            ViewBag.WelcomeMessage = "Welcome to the Movie House";
            return View(_movieRepository.AllMovies);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodList()
        {
            var food = new List<string>()
            {
                "Yam", "Beans", "Fried Rice", "Potato", "Amala", "Wheat"
            };
            ViewBag.Food = food;
            ViewBag["Food"] = food;
            ViewData["Food"] = food;
            return View();
        }
    }
}
