using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;

namespace JopOffers.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Data; 
        public UnitOfWork(AppDbContext d) {
            Data = d;
            Categories = new Repository<Category>(Data);
            Users = new Repository<User>(Data);
            Jobs = new Repository<Jobs>(Data);
            ApplyForJobs = new Repository<ApplyForJobs>(Data);
            Contacts = new Repository<Contact>(Data);

        }
        public IRepository<Category> Categories { get; private set; }

        public IRepository<User> Users { get; private set; }


        public IRepository<Jobs> Jobs { get; private set; }


        public IRepository<ApplyForJobs> ApplyForJobs { get; private set; }
        public IRepository<Contact> Contacts { get; private set; }


        public int commitChanges()
        {
            return Data.SaveChanges();  
        }

        public void Dispose()
        {
           Data.Dispose();
        }
    }
}
