using System.ComponentModel.DataAnnotations;

namespace bruhBruh.Models
{
    public class veggies
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Veggie Name")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Letters allowed.")]
        public string? Name { get; set; }
        [StringLength(4, MinimumLength = 2)]
        public int? Weight { get; set; }
        
        public string? Size { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed.")]
        public int? Value { get; set; }

        public ICollection<retailLocation> Location { get; set; } = default!;
    }
}
