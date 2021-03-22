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
    /// Snippets queries and management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SnippetsController : ControllerBase
    {
        /// <summary>
        /// IMapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// ISnippetsService instance
        /// </summary>
        private readonly ISnippetsService _snippetsService;

        public SnippetsController(
            IMapper mapper,
            ISnippetsService snippetsService)
        {
            _mapper = mapper;
            _snippetsService = snippetsService;
        }

        /// <summary>
        /// Checks sended snippet code compilation.
        /// </summary>
        /// <param name="snippet">Snippet's object</param>
        /// <returns>Object with rextester's response </returns>
        [HttpPost]
        [Route("")]
        public async Task<RextesterResponseDto> CheckCodeCompilation(SnippetPayload snippet)
        {
            var result = await _snippetsService.CheckCodeCompilationAsync(snippet);

            return _mapper.Map<RextesterResponseDto>(result);
        }

        /// <summary>
        /// Returns list of available programming languages.
        /// </summary>
        /// <returns>List of available programming languages</returns>
        [HttpGet]
        [Route("available-coding-languages")]
        public List<ProgrammingLanguageDto> GetAvailableProgrammingLanguages()
        {
            var result = _snippetsService.GetAvailableProgrammingLanguages();

            return _mapper.Map<List<ProgrammingLanguageDto>>(result);
        }
    }
}
