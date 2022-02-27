using CampaignModule.Data.Access.Entity;
using CampaignModule.Data.Access.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignModule.Data.Access.Repository
{
    public class OrderRepository : IOrderRepository<Orders>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Orders> AddAsync(Orders @object)
        {
            var obj = await _applicationDbContext.Orders.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _applicationDbContext.Orders;
        }

        public IEnumerable<Orders> GetByProductCode(string productCode)
        {
            return _applicationDbContext.Orders.Where(x => x.ProductCode.Equals(productCode)).ToList();
        }

        public void Update(Orders @object)
        {
            _applicationDbContext.Orders.Update(@object);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Orders @object)
        {
            _applicationDbContext.Remove(@object);
            _applicationDbContext.SaveChanges();
        }
    }
}
