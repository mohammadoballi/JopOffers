namespace JopOffers.Models.Repository.Base
{
    public interface IUserRepository
    {
        public bool Login(User user);
        public void Registration(User user);
        public void getUserType();
    }
}
