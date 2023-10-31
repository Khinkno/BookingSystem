using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.IServices;
using BookingSystem.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace BookingSystem.Controllers
{


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        private readonly ILogger<PackageController> _logger;
        private readonly IMapper _mapper;
        private readonly IScheduleService _scheduleService;
        private IDistributedCache _distributedCache;

        public ScheduleController(ILogger<PackageController> logger, IMapper mapper, IScheduleService scheduleService, IDistributedCache distributedCache)

        {
            _logger = logger;
            _mapper = mapper;
            _scheduleService = scheduleService;
            _distributedCache = distributedCache;
        }

        [Route("GetClassSchedule")]
        [HttpGet]
        public async Task<ActionResult> GetClassSchedule()
        {
            //UserInfo user;
            int countryid = UserController.countryid;
            return Ok(await _scheduleService.GetclassSchedule(countryid));

        }

        [Route("Booking")]
        [HttpPost]
        public async Task<string> Booking([FromBody] BookingDTO bookingDTO)
        {

            booking booking = _mapper.Map<booking>(bookingDTO);
            string result = await _scheduleService.CreateBooking(booking);
            return result;
            //if (result == null)
            //    return NotFound("Not Enough Credits");
            //else
            //    return Ok(await _scheduleService.CreateBooking(booking));


        }
        [Route("CancelBooking")]
        [HttpPost]
        public async Task<string> CancelBooking([FromBody] BookingDTO bookingDTO)
        {
            booking booking = _mapper.Map<booking>(bookingDTO);
            string result = await _scheduleService.CancelBooking(booking);
            return result;


        }

    }
}
