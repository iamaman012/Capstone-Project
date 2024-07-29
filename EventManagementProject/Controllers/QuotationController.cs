using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IPvtQuotationRequestService _pvtQuotationRequestService;
        private readonly  IPvtQuotationResponseService _pvtQuotationResponseService;
       

        public QuotationController(IPvtQuotationRequestService pvtQuotationRequestService, IPvtQuotationResponseService pvtQuotationResponseService)
        {
            _pvtQuotationRequestService = pvtQuotationRequestService;
            _pvtQuotationResponseService = pvtQuotationResponseService;
           
        }

        [HttpPost("add/pvt")]
        public async Task<IActionResult> AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto)
        {
            try
            {
                await _pvtQuotationRequestService.AddPvtQuotationRequest(pvtQuotationRequestDto);
                return Ok("Private Quotation Request Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("return/pvt")]
        public async Task<IActionResult> ReturnPvtQuotation()
        {
            try
            {
                var pvtQuotations = await _pvtQuotationRequestService.ReturnPvtQuotation();
                return Ok(pvtQuotations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add/pvt/response")]
        public async Task<IActionResult> AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO)
        {
            try
            {
                await _pvtQuotationResponseService.AddQuotationResponse(pvtQuotationResponseDTO);
                return Ok("Private Quotation Response Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pvt/response/ByuserId")]
        public async Task<IActionResult> GetPrivateQuotationResponseByUserId(int userId)
        {
            try
            {
                var responses = await _pvtQuotationResponseService.GetQuotationResponseByuserId(userId);
                return Ok(responses);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      

    }
}
