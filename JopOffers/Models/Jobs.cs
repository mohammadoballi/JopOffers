using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JopOffers.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
    
        public Category Category { get; set; } // one of category
        /// <summary>
        /// The UserId field to store companyId
        /// </summary>
        [Display(Name ="CompanyId")]
        public int UserId { get; set; }
        public User User { get; set; } //one of user


        public IEnumerable<ApplyForJobs> ApplyForJobs { get; set; } // many of applyforJobs

    }
}
