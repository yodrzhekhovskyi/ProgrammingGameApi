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
                Thread.Sleep(1000);
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

        /// <summary>
        /// Checks code compilation and whether or not snippet is correct
        /// </summary>
        /// <param name="snippetPayload">Snippet payload</param>
        /// <param name="testCase">Test case data</param>
        /// <returns>Whether or not snippet is correct</returns>
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

            return CheckResultCorrectness(result.Result, testCase.Result);
        }

        /// <summary>
        /// Check if expected result matches result from the server.
        /// </summary>
        /// <param name="result">Result from the server</param>
        /// <param name="expectedResult">Expected result</param>
        /// <returns>Whether or not result is correct</returns>
        private bool CheckResultCorrectness(string result, object expectedResult)
        {
            var correct = false;

            if (expectedResult is int @int)
            {
                int.TryParse(result, out int convertedResult);
                correct = convertedResult == @int;
            }
            else if (expectedResult is bool @bool)
            {
                bool.TryParse(result, out bool convertedResult);
                correct = convertedResult == @bool;
            }
            else if (expectedResult is decimal @decimal)
            {
                decimal.TryParse(result, out decimal convertedResult);
                correct = convertedResult == @decimal;
            }
            else if (expectedResult is double @double)
            {
                double.TryParse(result, out double convertedResult);
                correct = convertedResult == @double;
            }
            else if (expectedResult is long @long)
            {
                long.TryParse(result, out long convertedResult);
                correct = convertedResult == @long;
            }
            else if (expectedResult is DateTime @dateTime)
            {
                DateTime.TryParse(result, out DateTime convertedResult);
                correct = convertedResult == @dateTime;
            }
            else if (expectedResult is string @string)
            {
                correct = result == @string;
            }

            return correct;
        }
    }
}
