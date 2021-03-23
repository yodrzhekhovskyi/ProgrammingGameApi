namespace ProgrammingGameApi.Services.HelperClasses
{
    /// <summary>
    /// Rextester snippet item model
    /// </summary>
    public class RextesterSnippetItem
    {
        /// <summary>
        /// Language code <see cref="SnippetLanguageCode"/>
        /// </summary>
        public int LanguageChoice { get; set; }

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
