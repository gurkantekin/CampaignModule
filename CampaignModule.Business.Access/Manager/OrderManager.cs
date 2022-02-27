using System.Collections.Generic;
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
    public class OrderManager
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository<Orders> _orderRepository;
        public OrderManager(IMapper mapper, IOrderRepository<Orders> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Add(OrderDto order)
        {
            try
            {
                var orders = await _orderRepository.AddAsync(_mapper.Map<Orders>(order));

                return _mapper.Map<OrderDto>(orders);
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
                    TableName = RegularTableConstant.OrdersTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public List<OrderDto> GetByProductCode(string productCode)
        {
            try
            {
                return _mapper.Map<List<OrderDto>>(_orderRepository.GetByProductCode(productCode));
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
                    TableName = RegularTableConstant.OrdersTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Update(OrderDto orderDto)
        {
            try
            {
                var orders = _orderRepository.GetAll().ToList();

                foreach (var item in orders)
                {
                    _orderRepository.Update(_mapper.Map<Orders>(item));
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
                    TableName = RegularTableConstant.OrdersTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var orders = _orderRepository.GetAll().Where(x => x.Id.Equals(id)).ToList();

                foreach (var order in orders)
                {
                    _orderRepository.Delete(_mapper.Map<Orders>(order));
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
                    TableName = RegularTableConstant.OrdersTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
    }
}
