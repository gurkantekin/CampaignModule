using AutoMapper;
using CampaignModule.Data.Access.Dto;
using CampaignModule.Data.Access.Entity;
using CampaignModule.Data.Access.Interface;
using CampaignModule.Exception.Handler;
using CampaignModule.Exception.Handler.Model;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CampaignModule.Business.Access.Manager
{
    public class ProductsManager
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository<Products> _productRepository;
        public ProductsManager(IMapper mapper, IProductRepository<Products> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Add(ProductDto product)
        {
            try
            {
                var products = await _productRepository.AddAsync(_mapper.Map<Products>(product));

                return _mapper.Map<ProductDto>(products);
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Add,
                    TableName = RegularTableConstant.ProductsTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public ProductDto GetByProductCode(string productCode)
        {
            try
            {
                return _mapper.Map<ProductDto>(_productRepository.GetByProductCode(productCode));
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Select,
                    TableName = RegularTableConstant.ProductsTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Update(ProductDto productDto)
        {
            try
            {
                var products = _productRepository.GetAll().ToList();

                foreach (var item in products)
                {
                    _productRepository.Update(_mapper.Map<Products>(item));
                }

                return true;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Update,
                    TableName = RegularTableConstant.ProductsTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Delete(string productCode)
        {
            try
            {
                var products = _productRepository.GetAll().Where(x => x.ProductCode.Equals(productCode)).ToList();

                foreach (var product in products)
                {
                    _productRepository.Delete(_mapper.Map<Products>(product));
                }

                return true;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Delete,
                    TableName = RegularTableConstant.ProductsTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
    }
}
