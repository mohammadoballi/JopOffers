using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace JopOffers.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

       

        public IEnumerable<Jobs> Jobs { get; set; } // many of jops
    }
}
