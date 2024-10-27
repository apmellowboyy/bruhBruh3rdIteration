using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruhBruh.Models
{
    public class Fruits
    {
        [Required]
        public int Id { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value.")]
        public int? Value  { get; set; }

        public ICollection<retailLocation> Location { get; set; } = default!;

        
        
    }
}
