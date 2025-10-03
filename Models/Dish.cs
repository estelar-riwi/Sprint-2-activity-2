using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint2Activity2.Models
{
    [Table("Dishes")]
    public class Dish
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string? Description { get; set; }
        [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
        [Required] public string Category { get; set; }
    }
}