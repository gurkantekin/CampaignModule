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
    public class CampaignManager
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository<Campaigns> _campaignRepository;
        public CampaignManager(IMapper mapper, ICampaignRepository<Campaigns> campaignRepository)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
        }

        public async Task<CampaignDto> Add(CampaignDto campaign)
        {
            try
            {
                var campaing = await _campaignRepository.AddAsync(_mapper.Map<Campaigns>(campaign));

                return _mapper.Map<CampaignDto>(campaing);
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
                    TableName = RegularTableConstant.CampaignTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public CampaignDto GetByName(string name)
        {
            try
            {
                return _mapper.Map<CampaignDto>(_campaignRepository.GetByName(name));
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
                    TableName = RegularTableConstant.CampaignTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Update(CampaignDto campaignDto)
        {
            try
            {
                var campaigns = _campaignRepository.GetAll().ToList();

                foreach (var item in campaigns)
                {
                    _campaignRepository.Update(_mapper.Map<Campaigns>(item));
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
                    TableName = RegularTableConstant.CampaignTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Delete(string name, string productCode)
        {
            try
            {
                var campaigns = _campaignRepository.GetAll().Where(x => x.Name.Equals(name) && x.ProductCode.Equals(productCode)).ToList();

                foreach (var campaign in campaigns)
                {
                    _campaignRepository.Delete(_mapper.Map<Campaigns>(campaign));
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
                    TableName = RegularTableConstant.CampaignTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
    }
}
