namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// Rextester response
    /// </summary>
    public class RextesterResponseDto
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
        /// Not logged in
        /// </summary>
        public bool NotLoggedIn { get; set; }
    }
}
