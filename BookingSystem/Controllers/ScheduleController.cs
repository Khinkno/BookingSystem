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



        [Route("Booking")]
        [HttpPost]
        public async Task<ActionResult> Booking([FromBody] BookingDTO bookingDTO)
        {
            
            booking booking = _mapper.Map<booking>(bookingDTO);
            //return Ok(await _scheduleService.Booking(booking));
            var result = await _scheduleService.Booking(booking);
            if (result == null)
                return NotFound("Not Enough Credits");
            else
                return Ok(await _scheduleService.Booking(booking));

        }
        [Route("CancelBooking")]
        [HttpPost]
        public async Task<ActionResult> CancelBooking([FromBody] BookingDTO bookingDTO)
        {
            booking booking = _mapper.Map<booking>(bookingDTO);
            return Ok(await _scheduleService.CancelBooking(booking));


        }

    }
}
