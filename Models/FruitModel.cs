using System.ComponentModel.DataAnnotations;

namespace Pearmageddon.Models
{
    public class FruitModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Fruit Variety")]
        public virtual string Variety { get; set; }
    }
}