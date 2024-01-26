using JopOffers.Models;
using JopOffers.Models.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JopOffers.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork Data;
        public CategoryController(IUnitOfWork data)
        {
            Data = data;
        }

        public IActionResult Index()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                return View(Data.Categories.GetAllData());
            }
            return RedirectToAction("Login","User");
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Category category) {
            Data.Categories.Add(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          
            return View(Data.Categories.GetDataById(id));
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Data.Categories.Update(category);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(Data.Categories.GetDataById(id));
        }
   
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(Category category)
           {
            Data.Categories.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
