using JopOffers.Models;
using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using JopOffers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Diagnostics;

namespace JopOffers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplies applies;
        public HomeController(IApplies applies ,IUnitOfWork unitOfWork, ILogger<HomeController> logger, AppDbContext context)
        {
            _context= context;
            _logger = logger;
            _unitOfWork= unitOfWork;
            this.applies= applies;
        }

        public IActionResult Index()
        {
            var list = from c in _context.Categories
                       join j in _context.Jobs 
                       on c.Id equals j.CategoryId
                       group j by c.Id into  groupJobs
                       select new CategoryJobsVm { 
                           Category =_context.Categories.FirstOrDefault(c=>c.Id==groupJobs.Key),
                           Jobs = groupJobs.ToList()};
            
                    return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Details(int id)
        {
            var job = _unitOfWork.Jobs.GetDataById(id);

            var Userjobs = from j in _context.Jobs
                          join u in _context.Users
                          on j.UserId equals u.Id
                          into userJobs
                          select userJobs;

            ViewBag.CompanyName = Userjobs;

            return View(job);
        }


        public IActionResult ApplyList()
        {
            

            return View(applies.GetApplyPerUser());
        }
    }
}