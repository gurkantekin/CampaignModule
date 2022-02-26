namespace CampaignModule.Api.Core.Models.ResponseModel
{
    public class ErrorResponseModel<T>
    {
        public bool status { get; set; }
        public string message { get; set; }
        public T error { get; set; }
    }
}
