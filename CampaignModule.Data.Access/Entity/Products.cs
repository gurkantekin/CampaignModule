using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignModule.Data.Access.Entity
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}
