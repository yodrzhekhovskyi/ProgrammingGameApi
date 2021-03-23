namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// Rextester response
    /// </summary>
    public class RextesterResponseDto
    {
        /// <summary>
        /// Warnings, if any, as one string
        /// </summary>
        public string Warnings { get; set; }

        /// <summary>
        /// Errors, if any, as one string
        /// </summary>
        public string Errors { get; set; }

        /// <summary>
        /// Output of a program (in case of Sql Server - html)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Execution stats as one string
        /// </summary>
        public string Stats { get; set; }

        /// <summary>
        /// In case of Octave and R - list of png images encoded as base64 strings
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// Whether or not is logged in
        /// </summary>
        public bool NotLoggedIn { get; set; }
    }
}
