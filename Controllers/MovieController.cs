using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 6, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 7, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 8, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 9, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 10, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 11, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
            new Movie { MovieID = 12, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false },
            new Movie { MovieID = 13, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 14, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 15, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 16, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 17, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 18, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
            new Movie { MovieID = 19, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false },
            new Movie { MovieID = 20, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 21, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 22, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 23, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 24, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 25, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
            new Movie { MovieID = 26, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false }
        };

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

            var movie = movies.FirstOrDefault(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            var cartJson = HttpContext.Session.GetString("Cart");
            List<Movie> cart = string.IsNullOrEmpty(cartJson) ? new List<Movie>() : JsonSerializer.Deserialize<List<Movie>>(cartJson);

            if (cart.Any(m => m.MovieID == id))
            {
                TempData["Message"] = "This movie is already in your cart.";
                return RedirectToAction("Details", new { id });
            }

            cart.Add(movie);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

            return RedirectToAction("Index", "Cart");
        }
    }
}