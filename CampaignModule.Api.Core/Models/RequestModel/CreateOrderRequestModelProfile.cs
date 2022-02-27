using AutoMapper;
using CampaignModule.Data.Access.Dto;

namespace CampaignModule.Api.Core.Models.RequestModel
{
    public class CreateOrderRequestModelProfile : Profile
    {
        public CreateOrderRequestModelProfile()
        {
            CreateMap<CreateOrderRequestModel, OrderDto>();
        }
    }
}
