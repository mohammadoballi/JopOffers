using JopOffers.Models;

namespace JopOffers.ViewModels
{
    public class CategoryJobsVm
    {
        public Category Category { get; set; }
        public IEnumerable<Jobs> Jobs { get; set; }
    }
}
