using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampaignModule.Api.Core.Models.RequestModel;
using CampaignModule.Api.Core.Models.ResponseModel;
using CampaignModule.Business.Access.Manager;
using CampaignModule.Data.Access.Dto;
using CampaignModule.Exception.Handler.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CampaignModule.Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CampaignManager _campaignManager;
        private readonly ProductManager _productsManager;
        private readonly OrderManager _orderManager;

        public CampaignController(IMapper mapper, CampaignManager campaignManager, ProductManager productManager, OrderManager orderManager)
        {
            _mapper = mapper;
            _campaignManager = campaignManager;
            _productsManager = productManager;
            _orderManager = orderManager;
        }

        [HttpPost]
        [Route("create_campaign")]
        public async Task<ObjectResult> CreateCampaign([FromBody] CreateCampaignRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel<ModelStateDictionary>()
                {
                    status = false,
                    message = string.Empty,
                    error = ModelState
                });
            }
            try
            {
                var response = await _campaignManager.Add(_mapper.Map<CampaignDto>(model));

                if (response != null)
                    return Ok(new SuccessResponseModel<CampaignDto>()
                    {
                        status = true,
                        model = response
                    });
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    status = false,
                    message = ErrorMessageConstant.GeneralErrorMessage,
                    error = null
                });
            }
            catch (System.Exception exception)
            {
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    status = false,
                    message = exception.Message,
                    error = exception
                });
            }
        }

        [HttpPost]
        [Route("get_campaign_info")]
        public Task<ObjectResult> GetCampaignInfo([FromQuery] string campaignName)
        {
            if (string.IsNullOrEmpty(campaignName))
            {
                return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<string>()
                {
                    status = false,
                    message = ErrorMessageConstant.ParamErrorMessage,
                    error = null
                }));
            }
            try
            {
                var campaign = _mapper.Map<CampaignDto>(_campaignManager.GetByName(campaignName));
                if (campaign == null)
                    return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                    {
                        status = false,
                        message = ErrorMessageConstant.GeneralErrorMessage,
                        error = null
                    }));

                var product = _productsManager.GetByProductCode(campaign.ProductCode);

                if (product == null)
                    return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                    {
                        status = false,
                        message = ErrorMessageConstant.GeneralErrorMessage,
                        error = null
                    }));

                var targetSales = campaign.TargetSalesCount;
                var orders = _orderManager.GetByProductCode(product.ProductCode).ToList();
                var totalSales = orders.Count();
                var averageItemPrice = (product.Price + product.CurrentPrice) / 2;
                var turnover = totalSales * targetSales;
                var status = _campaignManager.ValidateCampaign(campaignName) ? CampaignStatus.Active : CampaignStatus.Ending;

                var response = new GetCampaignInfoResponseModel()
                {
                    Status = status,
                    TargetSales = targetSales,
                    TotalSales = totalSales,
                    Turnover = turnover,
                    AverageItemPrice = averageItemPrice
                };
                return Task.FromResult<ObjectResult>(Ok(new SuccessResponseModel<GetCampaignInfoResponseModel>()
                {
                    status = true,
                    model = response
                }));

            }
            catch (System.Exception exception)
            {
                return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    status = false,
                    message = exception.Message,
                    error = exception
                }));
            }
        }

        [HttpPost]
        [Route("increase_time")]
        public Task<ObjectResult> IncreaseTime([FromQuery] string campaignName, int hour)
        {
            if (hour == 0)
            {
                return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<string>()
                {
                    status = false,
                    message = ErrorMessageConstant.ParamErrorMessage,
                    error = null
                }));
            }
            try
            {
                var campaign = _mapper.Map<CampaignDto>(_campaignManager.GetByName(campaignName));
                if (campaign == null)
                    return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                    {
                        status = false,
                        message = ErrorMessageConstant.GeneralErrorMessage,
                        error = null
                    }));

                var campaing = _mapper.Map<CampaignDto>(_campaignManager.GetByName(campaignName));

                if (campaing == null)
                    return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                    {
                        status = false,
                        message = ErrorMessageConstant.GeneralErrorMessage,
                        error = null
                    }));
                var duration = campaing.Duration + hour;

                campaing.Duration = duration;
                var result = _campaignManager.Update(campaing);

                if (result)
                {
                    return Task.FromResult<ObjectResult>(Ok(new SuccessResponseModel<string>()
                    {
                        status = true,
                        model = $"Time is {duration}"
                    }));
                }

                return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    status = false,
                    message = ErrorMessageConstant.GeneralErrorMessage,
                    error = null
                }));
            }
            catch (System.Exception exception)
            {
                return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    status = false,
                    message = exception.Message,
                    error = exception
                }));
            }
        }
    }
}
