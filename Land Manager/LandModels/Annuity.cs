using System.ComponentModel.DataAnnotations;

namespace LandModels
{
    public class Annuity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Year { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
