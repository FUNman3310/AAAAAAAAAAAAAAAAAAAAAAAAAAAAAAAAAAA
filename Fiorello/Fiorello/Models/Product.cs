using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public string  Image { get; set; }

        public Category category { get; set; }
        [NotMapped]

        public IFormFile ImageFile { get; set; }
        
    }
}
