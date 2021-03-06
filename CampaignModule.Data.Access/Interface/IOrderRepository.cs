using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignModule.Data.Access.Interface
{
    public interface IOrderRepository<T>
    {
        public Task<T> AddAsync(T @object);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetByProductCode(string productCode);
        public void Update(T @object);
        public void Delete(T @object);
    }
}
