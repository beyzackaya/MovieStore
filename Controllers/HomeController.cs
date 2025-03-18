using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
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

            return View();
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