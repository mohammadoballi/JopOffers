using System.ComponentModel.DataAnnotations;

namespace JopOffers.Models
{
    public class ApplyForJobs
    {
        [Key]
        public int ApplyId { get; set; }

        public int JobsId { get; set; }
        public int UserId { get; set; }
        public string UploadCv { get; set; }
        public string Description { get; set; }

        public Jobs Jobs { get; set; }
        public User User { get; set; }  
    }
}
