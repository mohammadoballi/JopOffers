using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JopOffers.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext context;
        public Repository(AppDbContext _context)
        {
            context= _context;
        }
        public void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Add(T t, IFormFile UploadImage)
        {
           /* Jobs j = new Jobs();

            if (UploadImage != null && UploadImage.Length > 0)
            {
                var UniqeFileName = Guid.NewGuid().ToString() + "_" + UploadImage.FileName;
                string ImagePath = Path.Combine("wwwroot/Images", UniqeFileName);
                using (var streem = new FileStream(ImagePath, FileMode.Create))
                {
                    UploadImage.CopyToAsync(streem);
                }
                if (typeof(T) == typeof(Jobs))
                {
                    j = t;
                    j.Image = ImagePath;
                }
            }

            context.Add(t);
            context.SaveChanges();*/
        }

        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public IEnumerable<T>? GetAllData()=>context.Set<T>().ToList();

        public T GetDataById(int id) => context.Set<T>().Find(id);

        public void Update(T t)
        {
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
