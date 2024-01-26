using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JopOffers.Models.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private readonly AppDbContext Data;
        public JobsRepository(AppDbContext Data)
        {
                this.Data = Data;
        }
        public IEnumerable<Jobs> GetAll()=>Data.Jobs.Include(c=>c.Category);
        public void Add(Jobs job , IFormFile UploadImage)
        {
            var UniqeFileName = "";
            if (UploadImage != null && UploadImage.Length>0)
            {
                UniqeFileName = Guid.NewGuid().ToString()+"_"+UploadImage.FileName;
                string ImagePath = Path.Combine("wwwroot/Images",UniqeFileName);
                using (var streem = new FileStream(ImagePath, FileMode.Create))
                {
                    UploadImage.CopyToAsync(streem);
                }
                job.Image= UniqeFileName;
            }
            else
            {
                UniqeFileName = "/Images/6a461d4e-8e92-4109-ae9b-f3dcfbaca1ad_defaultjobicon.png";
                job.Image = UniqeFileName;
            }
            Data.Jobs.Add(job);
            Data.SaveChanges();
        }
    }
}
