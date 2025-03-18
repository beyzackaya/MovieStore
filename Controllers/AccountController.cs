using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            // Login sayfasını render ediyoruz
            return View();
        }

        [HttpPost]
        public IActionResult Login(string firstName, string lastName)
        {
            // Kullanıcı bilgilerini çerezlere kaydediyoruz
            var userInfo = $"{firstName} {lastName}";
            Response.Cookies.Append("UserInfo", userInfo);

            // Anasayfaya yönlendir
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Çerezleri temizliyoruz
            Response.Cookies.Delete("UserInfo");

            // Anasayfaya yönlendir
            return RedirectToAction("Index", "Home");
        }
    }
}