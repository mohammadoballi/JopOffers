using System.ComponentModel.DataAnnotations;

namespace JopOffers.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Jobs> Jobs { get; set; }
        public IEnumerable<ApplyForJobs> ApplyForJobs { get; set; }

    }
}
