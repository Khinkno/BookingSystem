using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.IServices;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookingSystem.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public static int countryid = 1;
        //public UserController(IConfiguration configuration, ITokenService tokenService)
        //{
        //    _configuration = configuration;
        //    _tokenService = tokenService;
        //}

        public UserController(IConfiguration configuration, ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] UserInfoDTO userDTO)
        {

            UserInfo user = _mapper.Map<UserInfo>(userDTO);
            return Ok(await _userService.RegisterUser(user));

        }



        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            //if (email != "admin@gmail.com" && password != "123")
            //    return Unauthorized("Invalid Credentials");
            //else
            //    return new JsonResult(new { userName = email, token = _tokenService.CreateToken(email) });

            var result = await _userService.GetUserLogin(email, password);

            if (result == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            else
            {
                //UserInfo user = _mapper.Map<UserInfo>(UserInfoDTO);
                countryid = result.countryid;
                return new JsonResult(new { userName = email, token = _tokenService.CreateToken(email) });
            }
        }

        [Route("GetProfile")]
        [HttpGet]
        public async Task<ActionResult> GetProfile(int userid)
        {
            
            return Ok(await _userService.GetProfile(userid));

        }
        [Route("ResetPassword")]
        [HttpPost]
        public async Task<string> ResetPassword(int userid,string oldpassword,string newpassword)
        {

          //  UserInfo user = _mapper.Map<UserInfo>(userDTO);
            string result= await _userService.ResetPassword(userid,oldpassword,newpassword);
            return result;

        }
    }
}
