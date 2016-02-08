using LandModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LandModels
{
    public class Leaseholder : IHolder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
