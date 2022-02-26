using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignModule.Data.Access.Entity
{
    [Table("Orders", Schema = "dbo")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        [Required]
        [Display(Name = "ProductCode")]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
