using System.ComponentModel.DataAnnotations;

namespace Pearmageddon.Models
{
    public class AppleModel : FruitModel
    {
        [Required]
        [Display(Name = "Apple Variety")]
        [RegularExpression("(Granny Smith|Red Delicious|Golden Delicious|Fuji|Honeycrisp|Gala|Cripps Pink|Braeburn|Jazz|Ambrosia|Envy|Kiku|Kanzi|Cosmic Crisp|Opal|Pacific Rose|Pinata|SweeTango|Zestar)", ErrorMessage = "Invalid apple variety")]
        public override string Variety { get; set; }
    }
}