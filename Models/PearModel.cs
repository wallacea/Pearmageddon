using System.ComponentModel.DataAnnotations;

public class PearModel{
    [Display(Name = "Pear Name")]
    [Required(ErrorMessage = "Please enter a name for the pear")]
    public string Name { get; set; }
    [Display(Name = "Pearish Color")]
    [Required(ErrorMessage = "Please enter a color for the pear")]
    [RegularExpression("\\d{3}\\-\\d{2}\\-\\d{4}", ErrorMessage ="Pear color must be in the format 000-00-0000")] 
    public string Color { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Texture { get; set; }
    public string? Flavor { get; set; }
    public string? Origin { get; set; }
    public string? Image { get; set; }
}