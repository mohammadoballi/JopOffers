using JopOffers.Models;
using JopOffers.Models.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace JopOffers.Controllers
{
    public class ApplyForJobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplyForJobsController(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Apply(int id )
        {
            HttpContext.Session.SetInt32("JobId", id);
            var UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Apply(ApplyForJobs apply , IFormFile Upload)
        {
            apply.JobsId = (int)HttpContext.Session.GetInt32("JobId");
            apply.UserId = (int)HttpContext.Session.GetInt32("UserId");
            if (Upload != null && Upload.Length > 0)
            {
                var UniqeFileName = Guid.NewGuid().ToString() + "_" + Upload.FileName;

                string FilePath = Path.Combine("wwwroot/ApplyFiles", UniqeFileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    Upload.CopyToAsync(stream);
                }

                apply.UploadCv = UniqeFileName;
                _unitOfWork.ApplyForJobs.Add(apply);
                return RedirectToAction("Index" , "Home");
            }

            return View();
        }


    }
}
