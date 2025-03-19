using Microsoft.AspNetCore.Authorization;
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
            var movies = new List<Movie>
            {
                new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false }
            };

            var movie = movies.FirstOrDefault(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            if (!Request.Cookies.ContainsKey("UserInfo"))
            {
                return RedirectToAction("Login", "Account");
            }

            var movies = new List<Movie>
            {
                new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false }
            };

            var movie = movies.FirstOrDefault(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            List<Movie> cart;
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                cart = new List<Movie>();
            }
            else
            {
                cart = JsonSerializer.Deserialize<List<Movie>>(cartJson);
            }

            cart.Add(movie);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

            return RedirectToAction("Index", "Cart");
        }
    }
}