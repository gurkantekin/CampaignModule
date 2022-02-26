namespace CampaignModule.Api.Core.Models.ResponseModel
{
    public class SuccessResponseModel<T>
    {
        public bool status { get; set; }
        public T model { get; set; }
    }
}
