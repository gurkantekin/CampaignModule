using AutoMapper;
using CampaignModule.Data.Access.Dto;

namespace CampaignModule.Api.Core.Models.RequestModel
{
    public class CreateCampaignRequestModelProfile : Profile
    {
        public CreateCampaignRequestModelProfile()
        {
            CreateMap<CreateCampaignRequestModel, CampaignDto>();
        }
    }
}
