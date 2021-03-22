using ProgrammingGameApi.Services.Helpers;
using ProgrammingGameApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ProgrammingGameApi.Services.Helpers.FakeDb.Models;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Stats queries and management
    /// </summary>
    public class StatsService : BaseService, IStatsService
    {
        /// <summary>
        /// <inheritdoc cref="IStatsService.GetStats"/>
        /// </summary>
        public List<UserStats> GetStats()
        {
            return _db.UsersStats;
        }

        /// <summary>
        /// <inheritdoc cref="IStatsService.GetStatsForLadder"/>
        /// </summary>
        public List<UserStats> GetStatsForLadder()
        {
            var result = _db.UsersStats
                .OrderByDescending(x => x.RiddlesSolved)
                .ThenByDescending(x => x.TotalSnippetsForRiddlesSent)
                .ThenByDescending(x => x.TotalCorrectCompilations)
                .ThenBy(x => x.UserName)
                .ToList();

            return result;
        }

        /// <summary>
        /// <inheritdoc cref="IStatsService.IncrementSolvedRiddleCount"/>
        /// </summary>
        public void IncrementSolvedRiddleCount()
        {
            if (LoggedUser == null)
            {
                return;
            }

            var userStats = _db.UsersStats.SingleOrDefault(x => x.UserId == LoggedUser.Id);
            userStats.RiddlesSolved++;
            userStats.TotalCorrectCompilations++;
        }

        /// <summary>
        /// <inheritdoc cref="IStatsService.IncrementTotalCorrectCompilations"/>
        /// </summary>
        public void IncrementTotalCorrectCompilations()
        {
            if (LoggedUser == null)
            {
                return;
            }

            var userStats = _db.UsersStats.SingleOrDefault(x => x.UserId == LoggedUser.Id);
            userStats.TotalCorrectCompilations++;
        }

        /// <summary>
        /// <inheritdoc cref="IStatsService.IncrementTotalAttemptsCount"/>
        /// </summary>
        public void IncrementTotalAttemptsCount()
        {
            if (LoggedUser == null)
            {
                return;
            }

            var userStats = _db.UsersStats.SingleOrDefault(x => x.UserId == LoggedUser.Id);
            userStats.TotalSnippetsForRiddlesSent++;
        }
    }
}
