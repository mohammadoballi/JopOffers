using JopOffers.Models.Data;
using Microsoft.AspNetCore.Identity;

namespace JopOffers.Models.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        
        public IEnumerable<T> GetAllData();
        
        public T GetDataById(int id);
        
        public void Add(T t);
        public void Add(T t , IFormFile UploadImage);
        public void Update(T t);
        public void Delete(T t);

    }
}
