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

        public CampaignController(IMapper mapper, CampaignManager campaignManager)
        {
            _mapper = mapper;
            _campaignManager = campaignManager;
        }
        [HttpPost]
        [Route("create_campaign")]
        public async System.Threading.Tasks.Task<ObjectResult> PostAsync([FromBody] CreateCampaignRequestModel model)
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
    }
}
