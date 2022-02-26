using AutoMapper;
using CampaignModule.Data.Access.Entity;

namespace CampaignModule.Data.Access.Dto
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDto>();
            CreateMap<ProductDto, Products>();
        }
    }
}
