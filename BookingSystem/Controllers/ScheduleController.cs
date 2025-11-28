using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.IServices;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;

namespace BookingSystem.Controllers
{


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        private readonly ILogger<ScheduleController> _logger;
        private readonly IMapper _mapper;
        private readonly IScheduleService _scheduleService;
        private IDistributedCache _distributedCache;
        private readonly IUserService _userService;
        public ScheduleController(ILogger<ScheduleController> logger, IMapper mapper, IScheduleService scheduleService, IDistributedCache distributedCache,IUserService userService)

        {
            _logger = logger;
            _mapper = mapper;
            _scheduleService = scheduleService;
            _distributedCache = distributedCache;
            _userService = userService;
        }

        [Route("GetClassSchedule")]
        [HttpGet]
        public async Task<ActionResult> GetClassSchedule()
        {
            //UserInfo user;
            ClaimsPrincipal currentUser = this.User;
            int userid = Convert.ToInt32(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int countryid = await _userService.GetCountryIdByUserid(userid);
            return Ok(await _scheduleService.GetclassSchedule(countryid));

        }

        [Route("Booking")]
        [HttpPost]
        public async Task<IActionResult> Booking([FromBody] BookingDTO bookingDTO)
        {

            booking booking = _mapper.Map<booking>(bookingDTO);
            string result = await _scheduleService.CreateBooking(booking);
            return Ok(new { message = result });
            //return result;
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
