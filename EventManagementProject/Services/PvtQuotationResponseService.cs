using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;

namespace EventManagementProject.Services
{
    public class PvtQuotationResponseService : IPvtQuotationResponseService
    {
        private readonly IPvtQuotationResponseRepository _pvtQuotationResponseRepository;
        private readonly IPvtQuotationRequestRepository _pvtQuotationRequestRepository;
        private readonly IUserRepository _userRepository;
        public PvtQuotationResponseService(IPvtQuotationResponseRepository pvtQuotationResponseRepository, IPvtQuotationRequestRepository pvtQuotationRequestRepository, IUserRepository userRepository)
        {
            _pvtQuotationResponseRepository = pvtQuotationResponseRepository;
            _pvtQuotationRequestRepository = pvtQuotationRequestRepository;
            _userRepository = userRepository;
        }
        public async Task AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO)
        {
            try
            {
                var pvtQuotationResponse = new PrivateQuotationResponse
                {
                    PrivateQuotationRequestId = pvtQuotationResponseDTO.PrivateQuotationRequestId,
                    QuotedAmount = pvtQuotationResponseDTO.QuotedAmount,
                    ResponseMessage = pvtQuotationResponseDTO.ResponseMessage,
                    RequestStatus = "Initiated",
                    ResponseDate = DateTime.Now,
                    IsAccepted = false
                };
                await _pvtQuotationResponseRepository.Add(pvtQuotationResponse);
                await _pvtQuotationRequestRepository.UpdateQuotationStatus(pvtQuotationResponseDTO.PrivateQuotationRequestId, "Responded");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       

       public async Task<IEnumerable<ReturnPvtQuotationResponseDTO>>GetQuotationResponseByuserId(int userId)
        {
            try
            {
                var responses = await _userRepository.GetQuotationResponseByUserId<PrivateQuotationResponse>(userId,"Private");
                var returnPvtQuotationResponses = responses.Select(response => new ReturnPvtQuotationResponseDTO
                {
                    PrivateQuotationResponseId = response.PrivateQuotationResponseId,
                    PrivateQuotationRequestId = response.PrivateQuotationRequestId,
                    QuotedAmount = response.QuotedAmount,
                    ResponseMessage = response.ResponseMessage,
                    EventName = response.PrivateQuotationRequest.Event.EventName,
                    AcceptedByYou = response.IsAccepted,
                });
                return returnPvtQuotationResponses;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
