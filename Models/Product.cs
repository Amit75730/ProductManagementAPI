using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public int UserId { get; set; }
    }
}
