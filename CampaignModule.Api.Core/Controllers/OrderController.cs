using AutoMapper;
using CampaignModule.Api.Core.Models.RequestModel;
using CampaignModule.Api.Core.Models.ResponseModel;
using CampaignModule.Business.Access.Manager;
using CampaignModule.Data.Access.Dto;
using CampaignModule.Exception.Handler.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace CampaignModule.Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly OrderManager _orderManager;

        public OrderController(IMapper mapper, OrderManager orderManager)
        {
            _mapper = mapper;
            _orderManager = orderManager;
        }

        [HttpPost]
        [Route("create_order")]
        public async Task<ObjectResult> CreateOrder([FromBody] CreateOrderRequestModel model)
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
                var response = await _orderManager.Add(_mapper.Map<OrderDto>(model));

                if (response != null)
                    return Ok(new SuccessResponseModel<OrderDto>()
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
    }
}
