namespace JopOffers.Models.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Category> Categories { get; }
        public IRepository<User> Users { get; }
        public IRepository<Jobs> Jobs { get; }
        public IRepository<ApplyForJobs> ApplyForJobs { get; }
        public IRepository<Contact> Contacts { get; }
        int commitChanges();


    }
}
