using JopOffers.Models;

namespace JopOffers.ViewModels
{
    public class UserJobs
    {
        public User user { get; set; }
        public IEnumerable<Jobs> jobs { get; set; }
    }
}
