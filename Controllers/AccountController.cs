using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string firstName, string lastName)
        {
            var userInfo = $"{firstName} {lastName}";
            Response.Cookies.Append("UserInfo", userInfo);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserInfo");
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}