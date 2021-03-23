using ProgrammingGameApi.Services;

namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// Rextester snippet item
    /// </summary>
    public class SnippetDto
    {
        /// <summary>
        /// Language code <see cref="SnippetLanguageCode"/>
        /// </summary>
        public SnippetLanguageCode Code { get; set; }

        /// <summary>
        /// Code to run
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Input to be supplied to stdin of a process
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Compiler args as one string (when applicable)
        /// </summary>
        public string CompilerArgs { get; set; }
    }
}
