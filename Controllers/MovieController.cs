using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Text.Json;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var moviesJson = HttpContext.Session.GetString("Movies");
            List<Movie> movies = new List<Movie>();

            if (!string.IsNullOrEmpty(moviesJson))
            {
                movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);
            }

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var moviesJson = HttpContext.Session.GetString("Movies");
            if (!string.IsNullOrEmpty(moviesJson))
            {
                var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);
                var movie = movies.FirstOrDefault(m => m.MovieID == id);
                if (movie != null)
                {
                    return View(movie);
                }
            }
            return NotFound();
        }
    }
}