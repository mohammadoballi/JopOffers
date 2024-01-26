using JopOffers.Models;
using JopOffers.Models.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JopOffers.Controllers
{
    public class JobController : Controller
    {
        private readonly IUnitOfWork _Data;
        private readonly IJobsRepository data;
        
        public JobController(IUnitOfWork data0 , IJobsRepository data1)
        {
            _Data = data0;
            data = data1;
        }
      
        public IActionResult Index()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                return View(data.GetAll());
            }
            return RedirectToAction("Login", "User");
        }
     
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(
                _Data.Categories.GetAllData(),
                "Id",
                "Name"
                );
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jobs job , IFormFile UploadImage)
        {
            ViewBag.CategoryId = new SelectList(
               _Data.Categories.GetAllData(),
               "Id",
               "Name"
               );
            job.CreationDate=DateTime.Now;
            var UserId = HttpContext.Session.GetInt32("UserId");
            job.UserId =  Convert.ToInt32(UserId);

            data.Add(job, UploadImage);
            return RedirectToAction("Index");
        }
       
        public IActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(
              _Data.Categories.GetAllData(),
              "Id",
              "Name"
              );
            return View(_Data.Jobs.GetDataById(id));
        }
        [HttpPost]
        public IActionResult Edit(Jobs job)
        {
            ViewBag.CategoryId = new SelectList(
              _Data.Categories.GetAllData(),
              "Id",
              "Name"
              );
            _Data.Jobs.Update(job);
            return RedirectToAction("Index");
        }
       
        public IActionResult Delete(int id)
        {
            return View(_Data.Jobs.GetDataById(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(Jobs job)
        {
            _Data.Jobs.Delete(job);
            return RedirectToAction("Index");
        }

    }
}
