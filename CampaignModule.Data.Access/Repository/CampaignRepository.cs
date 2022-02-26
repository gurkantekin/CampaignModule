using CampaignModule.Data.Access.Entity;
using CampaignModule.Data.Access.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignModule.Data.Access.Repository
{
    public class CampaignRepository : ICampaignRepository<Campaigns>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CampaignRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Campaigns> AddAsync(Campaigns @object)
        {
            var obj = await _applicationDbContext.Campaigns.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<Campaigns> GetAll()
        {
            return _applicationDbContext.Campaigns;
        }

        public Campaigns GetByName(string name)
        {
            return _applicationDbContext.Campaigns.FirstOrDefault(x => x.Name.Equals(name));
        }

        public void Update(Campaigns @object)
        {
            _applicationDbContext.Campaigns.Update(@object);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Campaigns @object)
        {
            _applicationDbContext.Remove(@object);
            _applicationDbContext.SaveChanges();
        }
    }
}
