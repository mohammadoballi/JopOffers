using JopOffers.ViewModels;

namespace JopOffers.Models.Repository.Base
{
    public interface IApplies
    {
        public IEnumerable<AppliesVM> GetApplyPerUser();
    }
}
