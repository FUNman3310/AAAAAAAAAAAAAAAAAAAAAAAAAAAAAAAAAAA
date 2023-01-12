using System.ComponentModel.DataAnnotations;

namespace Fiorello.Models
{
    public class Category
    {
        public int Id { get; set; }


        [Required]
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }


        


        public List<Product> Products { get; set; }
    }
}
