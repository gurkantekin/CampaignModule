using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignModule.Data.Access.Entity
{
    [Table("Campaigns", Schema = "dbo")]
    public class Campaigns
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [ForeignKey("Product")]
        [Required]
        [Display(Name = "ProductCode")]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public int Duration { get; set; }
        [Required]
        [Display(Name = "PriceManipulationLimit")]
        public int PriceManipulationLimit { get; set; }
        [Required]
        [Display(Name = "TargetSalesCount")]
        public int TargetSalesCount { get; set; }
    }
}


