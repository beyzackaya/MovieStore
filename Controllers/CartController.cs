using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MovieStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<Movie> cart = string.IsNullOrEmpty(cartJson) ? new List<Movie>() : JsonSerializer.Deserialize<List<Movie>>(cartJson);
            return View(cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            List<Movie> cart = string.IsNullOrEmpty(cartJson) ? new List<Movie>() : JsonSerializer.Deserialize<List<Movie>>(cartJson);

            var movie = cart.FirstOrDefault(m => m.MovieID == id);
            if (movie != null)
            {
                cart.Remove(movie);
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmOrder()
        {
            HttpContext.Session.Remove("Cart");
            TempData["OrderMessage"] = "Siparişiniz oluşturuldu.";
            return RedirectToAction("Index");
        }
    }
}