using AutoMapper;
using CampaignModule.Data.Access.Entity;

namespace CampaignModule.Data.Access.Dto
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaigns, CampaignDto>();
            CreateMap<CampaignDto, Campaigns>();
        }
    }
}
