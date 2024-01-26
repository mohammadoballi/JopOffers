namespace JopOffers.Models.Repository.Base
{
    public interface IApplyForJobsRepository
    {
        public IEnumerable<ApplyForJobs> getAppliesPerUser();
        public IEnumerable<ApplyForJobs> getAppliesPerCompany();
        public ApplyForJobs getAppliesById(int Id);
    }
}
