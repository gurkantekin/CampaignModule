using System.ComponentModel.DataAnnotations;

namespace CampaignModule.Api.Core.Models.RequestModel
{
    public class CreateCampaignRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int PriceManipulationLimit { get; set; }
        [Required]
        public int TargetSalesCount { get; set; }
    }
}
