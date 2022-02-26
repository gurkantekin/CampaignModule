using CampaignModule.Data.Access.Entity;
using CampaignModule.Data.Access.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignModule.Data.Access.Repository
{
    public class ProductRepository : IProductRepository<Products>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Products> AddAsync(Products @object)
        {
            var obj = await _applicationDbContext.Products.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            //await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<Products> GetAll()
        {
            return _applicationDbContext.Products;
        }

        public Products GetByProductCode(string productCode)
        {
            return _applicationDbContext.Products.FirstOrDefault(x => x.ProductCode.Equals(productCode));
        }

        public void Update(Products @object)
        {
            _applicationDbContext.Products.Update(@object);
            _applicationDbContext.SaveChanges();
        }
        public void Delete(Products @object)
        {
            _applicationDbContext.Remove(@object);
            _applicationDbContext.SaveChanges();
        }
    }
}
