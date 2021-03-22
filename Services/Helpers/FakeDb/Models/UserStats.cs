namespace ProgrammingGameApi.Services.Helpers.FakeDb.Models
{
    /// <summary>
    /// User stats model
    /// </summary>
    public class UserStats
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Total count if snippents were sent to solve riddles.
        /// </summary>
        public int TotalSnippetsForRiddlesSent { get; set; }

        /// <summary>
        /// Total count of correct code compilations. It counts compilations
        /// of code in playground and for code sent to solve riddles.
        /// </summary>
        public int TotalCorrectCompilations { get; set; }

        /// <summary>
        /// Total count of solved riddles.
        /// </summary>
        public int RiddlesSolved { get; set; }
    }
}
