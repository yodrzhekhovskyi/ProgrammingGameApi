using ProgrammingGameApi.Services.HelperClasses;
using ProgrammingGameApi.Services.PayloadClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingGameApi.Services.Interfaces
{
    public interface ISnippetsService
    {
        /// <summary>
        /// Sends code snippet to Rextester server to validate.
        /// </summary>
        /// <param name="snippet">Snippet's object</param>
        /// <returns>Object with rextester's response </returns>
        Task<RextesterResponse> SendCodeSnippetToServerAsync(SnippetPayload snippet);

        /// <summary>
        /// Returns list of available programming languages.
        /// </summary>
        /// <returns>List of available programming languages</returns>
        List<ProgrammingLanguage> GetAvailableProgrammingLanguages();

        /// <summary>
        /// Checks sended snippet code compilation. If succeeded and user is logged in -
        /// it will increment stat of total correct compilation for current user.
        /// </summary>
        /// <param name="snippet">Snippet's object</param>
        /// <returns>Object with rextester's response </returns>
        Task<RextesterResponse> CheckCodeCompilationAsync(SnippetPayload snippet);
    }
}
