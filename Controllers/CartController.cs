using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Text.Json;

namespace MovieStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<Movie> cart;
            if (string.IsNullOrEmpty(cartJson))
            {
                cart = new List<Movie>();
            }
            else
            {
                cart = JsonSerializer.Deserialize<List<Movie>>(cartJson);
            }

            return View(cart);
        }
    }
}