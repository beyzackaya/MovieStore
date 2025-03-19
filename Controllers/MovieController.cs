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
            new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/5b/X-Men_The_Last_Stand_theatrical_poster.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/2/26/Örümcek_Adam_2_film_posteri.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/3/32/Sm3poster0.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/7/76/Valkyrie_film_afişi.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "https://tr.web.img4.acsta.net/r_1920_1080/img/6b/c7/6bc7a13ca6446a603f160b4ab4414141.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 6, Title = "Inception", Director = "Christopher Nolan", Stars = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page", ReleaseYear = 2010, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", Alt = "Movie 6", Hidden = false },
            new Movie { MovieID = 7, Title = "The Dark Knight", Director = "Christopher Nolan", Stars = "Christian Bale, Heath Ledger, Aaron Eckhart", ReleaseYear = 2008, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", Alt = "Movie 7", Hidden = false },
            new Movie { MovieID = 8, Title = "Interstellar", Director = "Christopher Nolan", Stars = "Matthew McConaughey, Anne Hathaway, Jessica Chastain", ReleaseYear = 2014, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", Alt = "Movie 8", Hidden = false },
            new Movie { MovieID = 9, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Stars = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", Alt = "Movie 9", Hidden = false },
            new Movie { MovieID = 10, Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = "Tim Robbins, Morgan Freeman, Bob Gunton", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg", Alt = "Movie 10", Hidden = false },
            new Movie { MovieID = 11, Title = "Pulp Fiction", Director = "Quentin Tarantino", Stars = "John Travolta, Uma Thurman, Samuel L. Jackson", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg", Alt = "Movie 11", Hidden = false },
            new Movie { MovieID = 12, Title = "Fight Club", Director = "David Fincher", Stars = "Brad Pitt, Edward Norton, Helena Bonham Carter", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/Fight_Club_poster.jpg", Alt = "Movie 12", Hidden = false },
            new Movie { MovieID = 13, Title = "Forrest Gump", Director = "Robert Zemeckis", Stars = "Tom Hanks, Robin Wright, Gary Sinise", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg", Alt = "Movie 13", Hidden = false },
            new Movie { MovieID = 14, Title = "The Godfather", Director = "Francis Ford Coppola", Stars = "Marlon Brando, Al Pacino, James Caan", ReleaseYear = 1972, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg", Alt = "Movie 14", Hidden = false },
            new Movie { MovieID = 15, Title = "The Godfather Part II", Director = "Francis Ford Coppola", Stars = "Al Pacino, Robert De Niro, Robert Duvall", ReleaseYear = 1974, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Godfather_part_ii.jpg", Alt = "Movie 15", Hidden = false },
            new Movie { MovieID = 16, Title = "The Lord of the Rings: The Fellowship of the Ring", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Orlando Bloom", ReleaseYear = 2001, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/Lord_Rings_Fellowship_Ring.jpg", Alt = "Movie 16", Hidden = false },
            new Movie { MovieID = 17, Title = "The Lord of the Rings: The Two Towers", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Viggo Mortensen", ReleaseYear = 2002, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a1/Lord_Rings_Two_Towers.jpg", Alt = "Movie 17", Hidden = false },
            new Movie { MovieID = 18, Title = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Viggo Mortensen", ReleaseYear = 2003, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/48/Lord_Rings_Return_King.jpg", Alt = "Movie 18", Hidden = false },
            new Movie { MovieID = 19, Title = "The Avengers", Director = "Joss Whedon", Stars = "Robert Downey Jr., Chris Evans, Scarlett Johansson", ReleaseYear = 2012, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", Alt = "Movie 19", Hidden = false },
            new Movie { MovieID = 20, Title = "Avatar", Director = "James Cameron", Stars = "Sam Worthington, Zoe Saldana, Sigourney Weaver", ReleaseYear = 2009, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/1/12/Avatar-Film-Posteri.jpg", Alt = "Movie 20", Hidden = false },
            new Movie { MovieID = 21, Title = "Titanic", Director = "James Cameron", Stars = "Leonardo DiCaprio, Kate Winslet, Billy Zane", ReleaseYear = 1997, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/b/b3/Titanik_film.jpg", Alt = "Movie 21", Hidden = false },
            new Movie { MovieID = 22, Title = "Jurassic Park", Director = "Steven Spielberg", Stars = "Sam Neill, Laura Dern, Jeff Goldblum", ReleaseYear = 1993, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg", Alt = "Movie 22", Hidden = false },
            new Movie { MovieID = 23, Title = "The Lion King", Director = "Roger Allers, Rob Minkoff", Stars = "Matthew Broderick, Jeremy Irons, James Earl Jones", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3d/The_Lion_King_poster.jpg", Alt = "Movie 23", Hidden = false },
            new Movie { MovieID = 24, Title = "Back to the Future", Director = "Robert Zemeckis", Stars = "Michael J. Fox, Christopher Lloyd, Lea Thompson", ReleaseYear = 1985, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", Alt = "Movie 24", Hidden = false },
            new Movie { MovieID = 25, Title = "Star Wars: Episode IV - A New Hope", Director = "George Lucas", Stars = "Mark Hamill, Harrison Ford, Carrie Fisher", ReleaseYear = 1977, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", Alt = "Movie 25", Hidden = false },
            new Movie { MovieID = 26, Title = "The Terminator", Director = "James Cameron", Stars = "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn", ReleaseYear = 1984, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg", Alt = "Movie 26", Hidden = false },
            new Movie { MovieID = 27, Title = "Alien", Director = "Ridley Scott", Stars = "Sigourney Weaver, Tom Skerritt, John Hurt", ReleaseYear = 1979, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c3/Alien_movie_poster.jpg", Alt = "Movie 27", Hidden = false },
            new Movie { MovieID = 28, Title = "The Silence of the Lambs", Director = "Jonathan Demme", Stars = "Jodie Foster, Anthony Hopkins, Scott Glenn", ReleaseYear = 1991, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/The_Silence_of_the_Lambs_poster.jpg", Alt = "Movie 28", Hidden = false },
            new Movie { MovieID = 29, Title = "Schindler's List", Director = "Steven Spielberg", Stars = "Liam Neeson, Ben Kingsley, Ralph Fiennes", ReleaseYear = 1993, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/38/Schindler%27s_List_movie.jpg", Alt = "Movie 29", Hidden = false },
            new Movie { MovieID = 30, Title = "The Green Mile", Director = "Frank Darabont", Stars = "Tom Hanks, Michael Clarke Duncan, David Morse", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e2/The_Green_Mile_%28movie_poster%29.jpg", Alt = "Movie 30", Hidden = false }
       };

        private static List<Category> categories = new List<Category>
        {
            new Category
            {
                CategoryID = 1,
                Name = "Latest Trailers",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/5b/X-Men_The_Last_Stand_theatrical_poster.jpg", Alt = "Movie 1", Hidden = false },
            new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/2/26/Örümcek_Adam_2_film_posteri.jpg", Alt = "Movie 2", Hidden = false },
            new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/3/32/Sm3poster0.jpg", Alt = "Movie 3", Hidden = false },
            new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/7/76/Valkyrie_film_afişi.jpg", Alt = "Movie 4", Hidden = false },
            new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "https://tr.web.img4.acsta.net/r_1920_1080/img/6b/c7/6bc7a13ca6446a603f160b4ab4414141.jpg", Alt = "Movie 5", Hidden = false },
            new Movie { MovieID = 6, Title = "Inception", Director = "Christopher Nolan", Stars = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page", ReleaseYear = 2010, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", Alt = "Movie 6", Hidden = false },
            new Movie { MovieID = 7, Title = "The Dark Knight", Director = "Christopher Nolan", Stars = "Christian Bale, Heath Ledger, Aaron Eckhart", ReleaseYear = 2008, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", Alt = "Movie 7", Hidden = false },
            new Movie { MovieID = 8, Title = "Interstellar", Director = "Christopher Nolan", Stars = "Matthew McConaughey, Anne Hathaway, Jessica Chastain", ReleaseYear = 2014, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", Alt = "Movie 8", Hidden = false },
            new Movie { MovieID = 9, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Stars = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", Alt = "Movie 9", Hidden = false },
            new Movie { MovieID = 10, Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = "Tim Robbins, Morgan Freeman, Bob Gunton", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg", Alt = "Movie 10", Hidden = false },
            }
            },
            new Category
            {
                CategoryID = 2,
                Name = "Top Rated",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 11, Title = "Pulp Fiction", Director = "Quentin Tarantino", Stars = "John Travolta, Uma Thurman, Samuel L. Jackson", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg", Alt = "Movie 11", Hidden = false },
            new Movie { MovieID = 12, Title = "Fight Club", Director = "David Fincher", Stars = "Brad Pitt, Edward Norton, Helena Bonham Carter", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/Fight_Club_poster.jpg", Alt = "Movie 12", Hidden = false },
            new Movie { MovieID = 13, Title = "Forrest Gump", Director = "Robert Zemeckis", Stars = "Tom Hanks, Robin Wright, Gary Sinise", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg", Alt = "Movie 13", Hidden = false },
            new Movie { MovieID = 14, Title = "The Godfather", Director = "Francis Ford Coppola", Stars = "Marlon Brando, Al Pacino, James Caan", ReleaseYear = 1972, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg", Alt = "Movie 14", Hidden = false },
            new Movie { MovieID = 15, Title = "The Godfather Part II", Director = "Francis Ford Coppola", Stars = "Al Pacino, Robert De Niro, Robert Duvall", ReleaseYear = 1974, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Godfather_part_ii.jpg", Alt = "Movie 15", Hidden = false },
            new Movie { MovieID = 16, Title = "The Lord of the Rings: The Fellowship of the Ring", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Orlando Bloom", ReleaseYear = 2001, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/Lord_Rings_Fellowship_Ring.jpg", Alt = "Movie 16", Hidden = false },
            new Movie { MovieID = 17, Title = "The Lord of the Rings: The Two Towers", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Viggo Mortensen", ReleaseYear = 2002, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a1/Lord_Rings_Two_Towers.jpg", Alt = "Movie 17", Hidden = false },
            new Movie { MovieID = 18, Title = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", Stars = "Elijah Wood, Ian McKellen, Viggo Mortensen", ReleaseYear = 2003, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/48/Lord_Rings_Return_King.jpg", Alt = "Movie 18", Hidden = false },
            new Movie { MovieID = 19, Title = "The Avengers", Director = "Joss Whedon", Stars = "Robert Downey Jr., Chris Evans, Scarlett Johansson", ReleaseYear = 2012, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", Alt = "Movie 19", Hidden = false },
            new Movie { MovieID = 20, Title = "Avatar", Director = "James Cameron", Stars = "Sam Worthington, Zoe Saldana, Sigourney Weaver", ReleaseYear = 2009, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/1/12/Avatar-Film-Posteri.jpg", Alt = "Movie 20", Hidden = false },
             }
            },
            new Category
            {
                CategoryID = 3,
                Name = "Most Commented",
                Movies = new List<Movie>
                {
                  new Movie { MovieID = 21, Title = "Titanic", Director = "James Cameron", Stars = "Leonardo DiCaprio, Kate Winslet, Billy Zane", ReleaseYear = 1997, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/b/b3/Titanik_film.jpg", Alt = "Movie 21", Hidden = false },
            new Movie { MovieID = 22, Title = "Jurassic Park", Director = "Steven Spielberg", Stars = "Sam Neill, Laura Dern, Jeff Goldblum", ReleaseYear = 1993, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg", Alt = "Movie 22", Hidden = false },
            new Movie { MovieID = 23, Title = "The Lion King", Director = "Roger Allers, Rob Minkoff", Stars = "Matthew Broderick, Jeremy Irons, James Earl Jones", ReleaseYear = 1994, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3d/The_Lion_King_poster.jpg", Alt = "Movie 23", Hidden = false },
            new Movie { MovieID = 24, Title = "Back to the Future", Director = "Robert Zemeckis", Stars = "Michael J. Fox, Christopher Lloyd, Lea Thompson", ReleaseYear = 1985, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", Alt = "Movie 24", Hidden = false },
            new Movie { MovieID = 25, Title = "Star Wars: Episode IV - A New Hope", Director = "George Lucas", Stars = "Mark Hamill, Harrison Ford, Carrie Fisher", ReleaseYear = 1977, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", Alt = "Movie 25", Hidden = false },
            new Movie { MovieID = 26, Title = "The Terminator", Director = "James Cameron", Stars = "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn", ReleaseYear = 1984, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/70/Terminator1984movieposter.jpg", Alt = "Movie 26", Hidden = false },
            new Movie { MovieID = 27, Title = "Alien", Director = "Ridley Scott", Stars = "Sigourney Weaver, Tom Skerritt, John Hurt", ReleaseYear = 1979, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c3/Alien_movie_poster.jpg", Alt = "Movie 27", Hidden = false },
            new Movie { MovieID = 28, Title = "The Silence of the Lambs", Director = "Jonathan Demme", Stars = "Jodie Foster, Anthony Hopkins, Scott Glenn", ReleaseYear = 1991, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/The_Silence_of_the_Lambs_poster.jpg", Alt = "Movie 28", Hidden = false },
            new Movie { MovieID = 29, Title = "Schindler's List", Director = "Steven Spielberg", Stars = "Liam Neeson, Ben Kingsley, Ralph Fiennes", ReleaseYear = 1993, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/38/Schindler%27s_List_movie.jpg", Alt = "Movie 29", Hidden = false },
            new Movie { MovieID = 30, Title = "The Green Mile", Director = "Frank Darabont", Stars = "Tom Hanks, Michael Clarke Duncan, David Morse", ReleaseYear = 1999, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e2/The_Green_Mile_%28movie_poster%29.jpg", Alt = "Movie 30", Hidden = false }
      }
            }
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

        public IActionResult Category(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}