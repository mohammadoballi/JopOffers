namespace JopOffers.Models.Repository.Base
{
    public interface IJobsRepository
    {
        void Add(Jobs job, IFormFile uploadImage);
        IEnumerable<Jobs> GetAll();
    }
}
