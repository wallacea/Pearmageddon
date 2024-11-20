using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Pearmageddon.Models;
public class PearTypeModel
{
    public int? ID { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Pear type names may only contain letters")]
    public string Name { get; set; }
    [Required]
    public string Color { get; set; }
    [BindNever]
    public DateTime? Timestamp { get; set; }
}