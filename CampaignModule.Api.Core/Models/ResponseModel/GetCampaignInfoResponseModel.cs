namespace CampaignModule.Api.Core.Models.ResponseModel
{
    public class GetCampaignInfoResponseModel
    {
        public CampaignStatus Status { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public int Turnover { get; set; }
        public double AverageItemPrice { get; set; }
    }

    public enum CampaignStatus
    {
        Ending,
        Active
    }
}
