using JopOffers.Models;
using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace JopOffers.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository Data;
        private readonly AppDbContext _context;
        public UserController(IUserRepository Data ,AppDbContext _context)  {
            this.Data = Data;
            this._context = _context;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            Data.Registration(user);
            return View();
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user) {

            var usr = Data.Login(user);
            var userType = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            HttpContext.Session.SetInt32("UserId" , userType.Id);
            if (usr)
            {

            if(userType.UserType == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (userType.UserType == "Admin")
            {
                return RedirectToAction("Index", "Category");
            }
            else if (userType.UserType == "Company")
            {
                return RedirectToAction("Index", "Job");
            }

            }
        return View(user);
        }

    }
}
