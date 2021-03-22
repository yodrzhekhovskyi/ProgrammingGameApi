using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProgrammingGameApi.Services.Config;
using ProgrammingGameApi.Services.HelperClasses;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.PayloadClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Snippets queries and management
    /// </summary>
    public class SnippetsService : BaseService, ISnippetsService
    {
        /// <summary>
        /// IStatsService instance
        /// </summary>
        private readonly IStatsService _statsService;

        /// <summary>
        /// IOptions instance
        /// </summary>
        private readonly IOptions<RextesterConfig> _config;

        /// <summary>
        /// Creates new <see cref="SnippetsService"/>
        /// </summary>
        /// <param name="statsService">Stats service instance</param>
        /// <param name="config">Rextester config instance</param>
        public SnippetsService(
            IStatsService statsService, 
            IOptions<RextesterConfig> config)
        {
            _statsService = statsService;
            _config = config;
        }

        /// <summary>
        /// <inheritdoc cref="ISnippetsService.SendCodeSnippetToServerAsync(SnippetPayload)"/>
        /// </summary>
        public async Task<RextesterResponse> SendCodeSnippetToServerAsync(SnippetPayload snippet)
        {
            var content = new RextesterSnippetItem
            {
                LanguageChoice = (int)snippet.Code,
                Program = snippet.Program,
                Input = snippet.Input,
                CompilerArgs = snippet.CompilerArgs
            };

            var jsonInString = JsonConvert.SerializeObject(content);

            var response = await Client.PostAsync(_config.Value.RextesterApiUrl, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var responseBody = await response.Content.ReadAsStringAsync();

            var rextesterResponse = JsonConvert.DeserializeObject<RextesterResponse>(responseBody);

            return rextesterResponse;
        }

        /// <summary>
        /// <inheritdoc cref="ISnippetsService.CheckCodeCompilationAsync(SnippetPayload)"/>
        /// </summary>
        public async Task<RextesterResponse> CheckCodeCompilationAsync(SnippetPayload snippet)
        {
            var result = await SendCodeSnippetToServerAsync(snippet);

            if (result.Errors == null && LoggedUser != null)
            {
                _statsService.IncrementTotalCorrectCompilations();
            }

            return result;
        }

        /// <summary>
        /// <inheritdoc cref="ISnippetsService.GetAvailableProgrammingLanguages"/>
        /// </summary>
        public List<ProgrammingLanguage> GetAvailableProgrammingLanguages()
        {
            var enumNames = Enum.GetNames(typeof(SnippetLanguageCode)).ToList();

            var result = new List<ProgrammingLanguage> { };

            enumNames.ForEach(x =>
            {
                var programmingLanguage = new ProgrammingLanguage
                {
                    Name = x,
                    SnippetLanguageCode = (SnippetLanguageCode)Enum.Parse(typeof(SnippetLanguageCode), x)
                };

                result.Add(programmingLanguage);
            });

            return result;
        }
    }
}
