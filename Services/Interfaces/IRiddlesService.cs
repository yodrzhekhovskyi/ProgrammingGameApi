using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using ProgrammingGameApi.Services.PayloadClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingGameApi.Services.Interfaces
{
    public interface IRiddlesService
    {
        /// <summary>
        /// Finds and returns all riddles
        /// </summary>
        /// <returns>List of riddles</returns>
        List<Riddle> GetRiddles();

        /// <summary>
        /// Finds and returns riddle with specified id
        /// </summary>
        /// <param name="id">Identifier of riddle</param>
        /// <returns>Specified riddle</returns>
        Riddle GetRiddleById(int id);

        /// <summary>
        /// Checks if solution code for riddle is correct. It makes a call to Rextester api
        /// and runs some built-in tests.
        /// </summary>
        /// <param name="snippetPayload">Snippet's object</param>
        /// <param name="riddleId">Identifier of riddle</param>
        /// <returns>Whether or not solution is correct, null - if service is down</returns>
        Task<bool> CheckRiddleSolutionIsCorrectAsync(SnippetPayload snippetPayload, int riddleId);
    }
}
