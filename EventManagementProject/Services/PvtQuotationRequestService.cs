using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;

namespace EventManagementProject.Services
{
    public class PvtQuotationRequestService : IPvtQuotationRequestService
    {
        private readonly IPvtQuotationRequestRepository _pvtQuotationRequestRepository;
        private readonly IEventRepository _eventRepository;
        public PvtQuotationRequestService(IPvtQuotationRequestRepository pvtQuotationRequestRepository, IEventRepository eventRepository)
        {
            _pvtQuotationRequestRepository = pvtQuotationRequestRepository;
            _eventRepository = eventRepository;
        }
        public async Task AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto)
        {
            try
            {
                var pvtQuotationRequest = new PrivateQuotationRequest
                {
                    UserId = pvtQuotationRequestDto.UserId,
                    EventId = pvtQuotationRequestDto.EventId,
                    ExpectedPeopleCount = pvtQuotationRequestDto.ExpectedPeopleCount,
                    VenueType = pvtQuotationRequestDto.VenueType,
                    LocationDetails = pvtQuotationRequestDto.LocationDetails,
                    FoodPreference = pvtQuotationRequestDto.FoodPreference,
                    CateringInstructions = pvtQuotationRequestDto.CateringInstructions,
                    SpecialInstructions = pvtQuotationRequestDto.SpecialInstructions,
                    EventStartDate = pvtQuotationRequestDto.EventStartDate,
                    EventEndDate = pvtQuotationRequestDto.EventEndDate,
                    EventTiming = pvtQuotationRequestDto.EventTiming,
                    RequestedDate = DateTime.Now

                };
                pvtQuotationRequest.QuotationStatus = "Pending";
                await _pvtQuotationRequestRepository.Add(pvtQuotationRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ReturnPvtQuotationsDTO>> ReturnPvtQuotation()
        {
            try
            {
                var privateEvents = await _pvtQuotationRequestRepository.GetAll();
                var returnPvtQuotations = privateEvents.Select(pvtQuotationRequest => new ReturnPvtQuotationsDTO
                {
                    PrivateQuotationRequestId = pvtQuotationRequest.PrivateQuotationRequestId,
                    UserId = pvtQuotationRequest.UserId,
                    EventId = pvtQuotationRequest.EventId,
                    ExpectedPeopleCount = pvtQuotationRequest.ExpectedPeopleCount,
                    VenueType = pvtQuotationRequest.VenueType,
                    LocationDetails = pvtQuotationRequest.LocationDetails,
                    FoodPreference = pvtQuotationRequest.FoodPreference,
                    CateringInstructions = pvtQuotationRequest.CateringInstructions,
                    SpecialInstructions = pvtQuotationRequest.SpecialInstructions,
                    EventStartDate = pvtQuotationRequest.EventStartDate,
                    EventEndDate = pvtQuotationRequest.EventEndDate,
                    EventTiming = pvtQuotationRequest.EventTiming,
                    RequestedDate = pvtQuotationRequest.RequestedDate,
                    QuotationStatus = pvtQuotationRequest.QuotationStatus,
                    EventName = _eventRepository.GetById(pvtQuotationRequest.EventId).Result.EventName
                }) ;

                return returnPvtQuotations;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
