using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.IServices;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static BookingSystem.DTO.UserInfoDTO;

namespace BookingSystem.Controllers
{
    //public enum Country
    //{
    //    SelectCountry = 0,
    //    Myanmar = 1,
    //    Singapore = 2
    //}
    [Route("api/token")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

  

        public UserController(IConfiguration configuration, ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("RegisterUser")]
        [HttpPost]
        //public async Task<ActionResult> RegisterUser([FromBody] UserInfoDTO userDTO)
        public async Task<ActionResult> RegisterUser([Required]string name, [Required] string email, [Required] string phno, [Required] Country countryid, [Required][DataType(DataType.Password)] string password)
        {
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);

            //// 2. **Store the Hash:** Replace the plain text password with the hash.
            //user.password = hashedPassword;
            UserInfoDTO userDTO = new UserInfoDTO
            {
                name = name,
                email = email,
                phno = phno,
                countryid = countryid,
                password = password
            };
            UserInfo user = _mapper.Map<UserInfo>(userDTO);
            return Ok(await _userService.RegisterUser(user));

        }



        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, [DataType(DataType.Password)] string password)
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
                return new JsonResult(new { userName = result.userid, token = _tokenService.CreateToken(result.userid) });
            }
        }

        [Route("GetProfile")]
        [HttpGet]
        public async Task<ActionResult> GetProfile()
        {
            ClaimsPrincipal currentUser = this.User;
            int userid = Convert.ToInt32(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userid>0)
            {
                return Ok(await _userService.GetProfile(userid));
            }
            else
            {
                return Unauthorized("Please Login!");
            }

        }
        [Route("ResetPassword")]
        [HttpPost]
        public async Task<string> ResetPassword(string email, [DataType(DataType.Password)] string oldpassword, [DataType(DataType.Password)] string newpassword)
        {

            ClaimsPrincipal currentUser = this.User;
            int userid = Convert.ToInt32(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userid > 0)
            {
                string result = await _userService.ResetPassword(email, oldpassword, newpassword);
                return result;
            }
            else
            {
                return "Please Login!";
            }

        }
    }
}
