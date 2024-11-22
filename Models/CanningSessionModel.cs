using System.ComponentModel.DataAnnotations;

namespace Pearmageddon.Objects
{
    public class CanningSessionModel
    {
        public int? ID { get; set; }
        [Display(Name = "Pear Type")]
        public int PearTypeID { get; set; }
        [Display(Name = "Date Canned")]
        public DateTime DateCanned { get; set; }
        
    }
}
