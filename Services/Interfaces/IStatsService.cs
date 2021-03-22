using System.Collections.Generic;
using ProgrammingGameApi.Services.Helpers.FakeDb.Models;

namespace ProgrammingGameApi.Services.Interfaces
{
    public interface IStatsService
    {
        /// <summary>
        /// Returns all users stats
        /// </summary>
        /// <returns>List of stats</returns>
        List<UserStats> GetStats();

        /// <summary>
        /// Returns prepared stats list for ladder
        /// </summary>
        /// <returns>List of stats prepared for ladder</returns>
        List<UserStats> GetStatsForLadder();

        /// <summary>
        /// Increments count of solved riddles. It works only for logged used
        /// </summary>
        void IncrementSolvedRiddleCount();

        /// <summary>
        /// Increments count of total correct compilations. It works only for logged used
        /// </summary>
        void IncrementTotalCorrectCompilations();

        /// <summary>
        /// Increments count of total attempts. It works only for logged used
        /// </summary>
        void IncrementTotalAttemptsCount();
    }
}
