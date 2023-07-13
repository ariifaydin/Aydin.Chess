
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

        public IActionResult Login(LoginModel login)
        {
            Users girisAlanı = db.Users.FirstOrDefault(i => i.Username == login.Username && i.Password == login.Password);
            if (girisAlanı != null)
            {
                ViewBag.Durum = false;

                return RedirectToAction("Tahta");
            }
            ViewBag.Durum = true;

            //Users users = new Users();
            //users.Id = login.Id;
            //users.Username = login.Username;
            //users.Password = login.Password;
            //users.Email = login.Email;
            //db.Users.Add(users);
            //db.SaveChanges();
            return RedirectToAction("Tahta");
        }
      
    }
}
