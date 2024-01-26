using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using JopOffers.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JopOffers.Models.Repository
{
    public class Applies : IApplies
    {
        private readonly AppDbContext _context;
        public Applies(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AppliesVM> GetApplyPerUser()
        {
            var list = from j in _context.Jobs
                       join a in _context.ApplyForJobs
                       on j.Id equals a.JobsId
                       join u in _context.Users
                       on a.UserId equals u.Id
                       select new AppliesVM
                       {
                           Jobs = j,
                           User = u,
                           ApplyForJobs = a
                       };


            /*            var list = _context.ApplyForJobs.Include(j=>j.Jobs).Include(u=>u.User).ToList();
            */
            return list;
        }
    }
}
