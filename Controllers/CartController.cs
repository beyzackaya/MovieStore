using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}