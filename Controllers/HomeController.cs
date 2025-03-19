using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category
            {
                CategoryID = 1,
                Name = "Latest Trailers",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = "Patrick Stewart, Hugh Jackman, Halle Berry", ReleaseYear = 2006, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                    new Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Alfred Molina", ReleaseYear = 2004, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                    new Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = "Tobey Maguire, Kirsten Dunst, Topher Grace", ReleaseYear = 2007, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                    new Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = "Tom Cruise, Bill Nighy, Carice van Houten", ReleaseYear = 2008, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                    new Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = "Russell Crowe, Joaquin Phoenix, Connie Nielsen", ReleaseYear = 2000, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false }
                }
            },
            new Category
            {
                CategoryID = 2,
                Name = "Top Rated",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 6, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                    new Movie { MovieID = 7, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                    new Movie { MovieID = 8, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                    new Movie { MovieID = 9, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                    new Movie { MovieID = 10, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
                    new Movie { MovieID = 11, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
                    new Movie { MovieID = 12, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false }
                }
            },
            new Category
            {
                CategoryID = 3,
                Name = "Most Commented",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 13, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                    new Movie { MovieID = 14, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                    new Movie { MovieID = 15, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                    new Movie { MovieID = 16, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                    new Movie { MovieID = 17, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
                    new Movie { MovieID = 18, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
                    new Movie { MovieID = 19, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false }
                }
            },
            new Category
            {
                CategoryID = 4,
                Name = "Action",
                Movies = new List<Movie>
                {
                    new Movie { MovieID = 20, Title = "Movie 1", Director = "Director 1", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2001, ImageUrl = "movie1.jpg", Alt = "Movie 1", Hidden = false },
                    new Movie { MovieID = 21, Title = "Movie 2", Director = "Director 2", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2002, ImageUrl = "movie2.jpg", Alt = "Movie 2", Hidden = false },
                    new Movie { MovieID = 22, Title = "Movie 3", Director = "Director 3", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2003, ImageUrl = "movie3.jpg", Alt = "Movie 3", Hidden = false },
                    new Movie { MovieID = 23, Title = "Movie 4", Director = "Director 4", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2004, ImageUrl = "movie4.jpg", Alt = "Movie 4", Hidden = false },
                    new Movie { MovieID = 24, Title = "Movie 5", Director = "Director 5", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2005, ImageUrl = "movie5.jpg", Alt = "Movie 5", Hidden = false },
                    new Movie { MovieID = 25, Title = "Movie 6", Director = "Director 6", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2006, ImageUrl = "movie6.jpg", Alt = "Movie 6", Hidden = false },
                    new Movie { MovieID = 26, Title = "Movie 7", Director = "Director 7", Stars = "Star 1, Star 2, Star 3", ReleaseYear = 2007, ImageUrl = "movie7.jpg", Alt = "Movie 7", Hidden = false }
                }
            }
        };

        public IActionResult Index()
        {
            ViewBag.Categories = categories;
            var userInfo = Request.Cookies["UserInfo"];

            if (!string.IsNullOrEmpty(userInfo))
            {
                ViewBag.IsLoggedIn = true;
                ViewBag.UserName = userInfo; // Kullanıcı adını View'e gönder
            }
            else
            {
                ViewBag.IsLoggedIn = false;
            }

            return View(categories);
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var userInfo = $"{firstName} {lastName}";
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(1), // 1 ay boyunca sakla
                    HttpOnly = true
                };

                Response.Cookies.Append("UserInfo", userInfo, cookieOptions);
                return RedirectToAction("Index"); // Başarıyla giriş yaptıktan sonra ana sayfaya yönlendir
            }

            ViewBag.ErrorMessage = "Lütfen adınızı ve soyadınızı giriniz!";
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserInfo"); // Kullanıcı çerezini temizle
            return RedirectToAction("Index"); // Çıkış yaptıktan sonra ana sayfaya yönlendir
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}