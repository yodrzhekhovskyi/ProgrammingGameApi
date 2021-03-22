namespace ProgrammingGameApi.Services.HelperClasses
{
    /// <summary>
    /// Rextester response
    /// </summary>
    public class RextesterResponse
    {
        /// <summary>
        /// Warnings
        /// </summary>
        public string Warnings { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public string Errors { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Stats
        /// </summary>
        public string Stats { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// NotLoggedIn
        /// </summary>
        public bool NotLoggedIn { get; set; }
    }
}
