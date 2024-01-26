using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;

namespace JopOffers.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork Data;
        private readonly AppDbContext context;
        public UserRepository(IUnitOfWork _Data , AppDbContext context)
        {
            Data = _Data;
            this.context = context;
        }
        public  bool Login(User user)
        {   
            var usr = context.Users.SingleOrDefault(u => u.Email == user.Email);
            if (usr != null)
            {
                if(usr.Email== user.Email && usr.Password ==  user.Password) {
                    return true;
                }
            }
            return false; 
        }
    
        public void Registration(User user)
        {
            Data.Users.Add(user);
        }
        public void getUserType()
        {
            throw new NotImplementedException();
        }
    }
}
