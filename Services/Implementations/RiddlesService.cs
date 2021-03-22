using ProgrammingGameApi.Services.HelperClasses;
using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.PayloadClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Riddles queries and management
    /// </summary>
    public class RiddlesService : BaseService, IRiddlesService
    {
        /// <summary>
        /// ISnippetsService instance
        /// </summary>
        private readonly ISnippetsService _snippetsService;

        /// <summary>
        /// IStatsService instance
        /// </summary>
        private readonly IStatsService _statsService;

        /// <summary>
        /// Creates new <see cref="RiddlesService"/>
        /// </summary>
        /// <param name="snippetsService">Snippets service</param>
        /// <param name="statsService">Stats service</param>
        public RiddlesService(ISnippetsService snippetsService, IStatsService statsService)
        {
            _snippetsService = snippetsService;
            _statsService = statsService;
        }

        /// <summary>
        /// <inheritdoc cref="IRiddlesService.GetRiddles"/>
        /// </summary>
        public List<Riddle> GetRiddles()
        {
            return _db.Riddles;
        }

        /// <summary>
        /// <inheritdoc cref="IRiddlesService.GetRiddleById(int)"/>
        /// </summary>
        public Riddle GetRiddleById(int id)
        {
            return _db.Riddles.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// <inheritdoc cref="IRiddlesService.CheckRiddleSolutionIsCorrectAsync(SnippetPayload, int)"/>
        /// </summary>
        public async Task<bool> CheckRiddleSolutionIsCorrectAsync(SnippetPayload snippetPayload, int riddleId)
        {
            var riddle = _db.Riddles.SingleOrDefault(x => x.Id == riddleId);
            if (riddle == null)
            {
                throw new ArgumentException("Riddle is not found");
            }

            var testCases = riddle.TestCases;

            bool codeCorrect = false;

            var tasks = new List<Task<bool>>();

            testCases.ForEach(x =>
            {
                tasks.Add(CheckSnippetCorrectness(snippetPayload, x));
                // Stupid workaround to make a delay beetween calls to Rextesters api
                // since otherwise it will throw an error "Too many requests"
                Thread.Sleep(800);
            });

            var resultsOfTasks = await Task.WhenAll(tasks);

            if (!resultsOfTasks.Any(x => x == false)) {
                codeCorrect = true;
            }

            _statsService.IncrementTotalAttemptsCount();
            if (codeCorrect == true)
            {
                _statsService.IncrementSolvedRiddleCount();
            }

            return codeCorrect;
        }

        private async Task<bool> CheckSnippetCorrectness(SnippetPayload snippetPayload, TestCase testCase)
        {
            string input = string.Empty;

            var argsList = testCase.Args.ToList();
            input = string.Join(Environment.NewLine, argsList.Select(y => y.ToString()));
            snippetPayload.Input = input;

            var result = await _snippetsService.SendCodeSnippetToServerAsync(snippetPayload);

            if (string.IsNullOrEmpty(result.Result))
            {
                return false;
            }
            
            int.TryParse(result.Result, out int convertedResult);

            if (convertedResult != (int)testCase.Result)
            {
                return false;
            }

            return true;
        }
    }
}
