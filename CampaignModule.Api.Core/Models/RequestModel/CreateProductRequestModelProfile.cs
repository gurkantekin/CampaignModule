using AutoMapper;
using CampaignModule.Data.Access.Dto;

namespace CampaignModule.Api.Core.Models.RequestModel
{
    public class CreateProductRequestModelProfile : Profile
    {
        public CreateProductRequestModelProfile()
        {
            CreateMap<CreateProductRequestModel, ProductDto>();
        }
    }
}
