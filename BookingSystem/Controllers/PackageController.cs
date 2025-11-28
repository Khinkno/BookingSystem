using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.IServices;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.Controllers
{


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {

        private readonly ILogger<PackageController> _logger;
        private readonly IMapper _mapper;
        private readonly IPackageService _pkgService;
        private readonly IUserService _userService;
        public PackageController(ILogger<PackageController> logger, IMapper mapper, IPackageService pkgService,IUserService userService)

        {
            _logger = logger;
            _mapper = mapper;
            _pkgService = pkgService;
            _userService = userService;
        }

        [Route("GetPackages")]
        [HttpGet]
        public async Task<ActionResult> GetPackages()
        {
            try
            {
                //UserInfo user;
                //ClaimsPrincipal currentUser = this.User;
                //int userid = Convert.ToInt32(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                ClaimsPrincipal currentUser = this.User;
                string userIdString = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userid))
                {
                    return Unauthorized("Authentication failed: User ID not found in token.");
                }
                int countryid = await _userService.GetCountryIdByUserid(Convert.ToInt16(userid));
                return Ok(await _pkgService.GetPackages(countryid));
            }
            catch (Exception ex)
            {
            }
            return Unauthorized("You can't buy this package!");
        }

        [Route("BuyPackages")]
        [HttpPost]
        public async Task<ActionResult> BuyPackages([FromBody] UserPackageDTO user_PackageDTO)
        {
            ClaimsPrincipal currentUser = this.User;
            int userid = Convert.ToInt32(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int countryid = await _userService.GetCountryIdByUserid(userid);
            UserPackage user_package = _mapper.Map<UserPackage>(user_PackageDTO);
            Packages result = await _pkgService.GetCreditsByCountryid(countryid, user_package.pid);
            user_package.available_credits = result.no_of_credits;
           // user_package.available_credits
            if (result == null)
            {
                return Unauthorized("You can't buy this package!");
            }
            else
            {
                
                return Ok(await _pkgService.BuyPackages(user_package));
            }

        }
        [Route("MyPackageLists")]
        [HttpGet]
        public async Task<ActionResult> GetPurchasedPackages()
        {
            ClaimsPrincipal currentUser = this.User;
            string? userid = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _pkgService.GetPurchasedPackages(Convert.ToInt32(userid)));

        }

    }
}
