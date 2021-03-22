using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingGameApi.Dtos;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.PayloadClasses;

namespace ProgrammingGameApi.Controllers
{
    /// <summary>
    /// Riddles queries and management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RiddlesController : ControllerBase
    {
        /// <summary>
        /// IMapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// IRiddlesService instance
        /// </summary>
        private readonly IRiddlesService _riddlesService;

        public RiddlesController(
            IMapper mapper,
            IRiddlesService riddlesService)
        {
            _mapper = mapper;
            _riddlesService = riddlesService;
        }

        /// <summary>
        /// Finds and returns all riddles
        /// </summary>
        /// <returns>List of riddles</returns>
        [HttpGet]
        [Route("")]
        public List<RiddleDto> GetRiddlesList()
        {
            return _mapper.Map<List<RiddleDto>>(_riddlesService.GetRiddles());
        }

        /// <summary>
        /// Finds and returns riddle with specified id
        /// </summary>
        /// <param name="id">Identifier of riddle</param>
        /// <returns>Specified riddle</returns>
        [HttpGet]
        [Route("{id:int}")]
        public RiddleDto GetRiddle(int id)
        {
            return _mapper.Map<RiddleDto>(_riddlesService.GetRiddleById(id));
        }

        /// <summary>
        /// Checks if solution code for riddle is correct.
        /// </summary>
        /// <param name="snippetPayload">Snippet's object</param>
        /// <param name="riddleId">Identifier of riddle</param>
        /// <returns>Whether or not solution is correct</returns>
        [HttpPost]
        [Route("{id:int}/check-solution")]
        public async Task<bool> CheckRiddleSolution(SnippetPayload snippetPayload, int id)
        {
            var result = await _riddlesService.CheckRiddleSolutionIsCorrectAsync(snippetPayload, id);

            return result;
        }
    }
}
