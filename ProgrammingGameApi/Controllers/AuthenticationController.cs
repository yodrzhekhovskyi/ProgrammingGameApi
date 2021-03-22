using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingGameApi.Dtos;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.PayloadClasses;

namespace ProgrammingGameApi.Controllers
{
    /// <summary>
    /// Authentication management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// IMapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// IAuthenticationService instance
        /// </summary>
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Logins user
        /// </summary>
        /// <param name="userPayload">User's data object</param>
        /// <returns>Logged user</returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserPayload userPayload)
        {
            var user = _authenticationService.Login(userPayload);

            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Registers user
        /// </summary>
        /// <param name="userPayload">User's data object</param>
        /// <returns>Registered user</returns>
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserPayload userPayload)
        {
            var user = _authenticationService.Register(userPayload);

            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Logouts user
        /// </summary>
        /// <returns>Ok result</returns>
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            _authenticationService.Logout();

            return Ok();
        }
    }
}
