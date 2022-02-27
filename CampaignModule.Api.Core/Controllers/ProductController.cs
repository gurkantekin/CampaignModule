using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using CampaignModule.Api.Core.Models.RequestModel;
using CampaignModule.Api.Core.Models.ResponseModel;
using CampaignModule.Business.Access.Manager;
using CampaignModule.Data.Access.Dto;
using CampaignModule.Exception.Handler.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CampaignModule.Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductManager _productsManager;

        public ProductController(IMapper mapper, ProductManager productManager)
        {
            _mapper = mapper;
            _productsManager = productManager;
        }

        [HttpPost]
        [Route("create_product")]
        public async Task<ObjectResult> CreateProduct([FromBody] CreateProductRequestModel model)
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
                var response = await _productsManager.Add(_mapper.Map<ProductDto>(model));

                if (response != null)
                    return Ok(new SuccessResponseModel<ProductDto>()
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
        [Route("get_product_info")]
        public Task<ObjectResult> GetProductInfo([FromQuery] string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
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
                var product = _productsManager.GetByProductCode(productCode);

                if (product == null)
                    return Task.FromResult<ObjectResult>(BadRequest(new ErrorResponseModel<System.Exception>()
                    {
                        status = false,
                        message = ErrorMessageConstant.GeneralErrorMessage,
                        error = null
                    }));

                return Task.FromResult<ObjectResult>(Ok(new SuccessResponseModel<ProductDto>()
                {
                    status = true,
                    model = product
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
