using AutoMapper;
using CampaignModule.Data.Access.Entity;

namespace CampaignModule.Data.Access.Dto
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Orders, OrderDto>();
            CreateMap<OrderDto, Orders>();
        }
    }
}
