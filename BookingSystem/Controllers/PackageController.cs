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

        public PackageController(ILogger<PackageController> logger, IMapper mapper, IPackageService pkgService)

        {
            _logger = logger;
            _mapper = mapper;
            _pkgService = pkgService;
        }

        [Route("GetPackages")]
        [HttpGet]
        public async Task<ActionResult> GetPackages()
        {
            //UserInfo user;
            int countryid = UserController.countryid;
            return Ok(await _pkgService.GetPackages(countryid));

        }

        [Route("BuyPackages")]
        [HttpPost]
        public async Task<ActionResult> BuyPackages([FromBody] user_packageDTO user_PackageDTO)
        {

            UserPackage user_package = _mapper.Map<UserPackage>(user_PackageDTO);
            Packages result = await _pkgService.GetCreditsByCountryid(UserController.countryid, user_package.pid);
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
        public async Task<ActionResult> GetPurchasedPackages(int userid)
        {
            //UserInfo user;
            
            return Ok(await _pkgService.GetPurchasedPackages(userid));

        }

    }
}
