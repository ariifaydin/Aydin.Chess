
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Web.UI.Entities.ContextDb;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class TransactionsController : Controller
    {
        DataContextDb db = new DataContextDb();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            Users girisAlanı = db.Users.FirstOrDefault(i => i.Email == login.Email && i.Password == login.Password);
            if (girisAlanı != null)
            {
                ViewBag.Durum = false;

                return View();
            }
            ViewBag.Durum = true;
            return RedirectToAction("Tahta","Satranc");
        }

        public IActionResult Register(LoginModel kayit)
        {
            Users Users = new Users();
            Users.Id = kayit.Id;
            Users.Username = kayit.Username;
            Users.Password = kayit.Password;
            Users.Email = kayit.Email;

            db.Users.Add(Users);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
      
    }
}
