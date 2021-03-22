using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingGameApi.Dtos;
using ProgrammingGameApi.Services.Interfaces;

namespace ProgrammingGameApi.Controllers
{
    /// <summary>
    /// Users queries and management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// IMapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// IUsersService instance
        /// </summary>
        private readonly IUsersService _usersService;

        public UsersController(
            IMapper mapper,
            IUsersService usersService)
        {
            _mapper = mapper;
            _usersService = usersService;
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns
        [HttpGet]
        [Route("")]
        public List<UserDto> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(_usersService.GetUsers());
        }

        /// <summary>
        /// Finds and returns user with specified identifier
        /// </summary>
        /// <param name="id">User's identifier</param>
        /// <returns>Specified user</returns>
        [HttpGet]
        [Route("{id:int}")]
        public UserDto GetUserById(int id)
        {
            return _mapper.Map<UserDto>(_usersService.GetUserById(id));
        }

        /// <summary>
        /// Updates user email
        /// </summary>
        /// <param name="id">User's identifier</param>
        /// <param name="newEmail">New user's email</param>
        /// <returns>Changed user</returns>
        [HttpPatch]
        [Route("{id:int}")]
        public UserDto UpdateUserEmail(int id, string newEmail)
        {
            return _mapper.Map<UserDto>(_usersService.UpdateUserEmail(id, newEmail));
        }
    }
}
