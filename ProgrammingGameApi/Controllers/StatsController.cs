using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingGameApi.Dtos;
using ProgrammingGameApi.Services.Interfaces;

namespace ProgrammingGameApi.Controllers
{
    /// <summary>
    /// Stats queries and management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        /// <summary>
        /// IMapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// IStatsService instance
        /// </summary>
        private readonly IStatsService _statsService;

        public StatsController(
            IMapper mapper,
            IStatsService statsService)
        {
            _mapper = mapper;
            _statsService = statsService;
        }

        /// <summary>
        /// Returns all users stats
        /// </summary>
        /// <returns>List of stats</returns>
        [HttpGet]
        [Route("")]
        public List<UserStatsDto> GetStats()
        {
            return _mapper.Map<List<UserStatsDto>>(_statsService.GetStats());
        }

        /// <summary>
        /// Returns prepared stats list for ladder
        /// </summary>
        /// <returns>List of stats prepared for ladder</returns>
        [HttpGet]
        [Route("ladder")]
        public List<UserStatsDto> GetStatsForLadder()
        {
            return _mapper.Map<List<UserStatsDto>>(_statsService.GetStatsForLadder());
        }
    }
}
