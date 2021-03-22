using ProgrammingGameApi.Services;

namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// Rextester snippet item
    /// </summary>
    public class SnippetDto
    {
        /// <summary>
        /// Language code 
        /// </summary>
        public SnippetLanguageCode Code { get; set; }

        /// <summary>
        /// Program code
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Input
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Compiler args
        /// </summary>
        public string CompilerArgs { get; set; }
    }
}
