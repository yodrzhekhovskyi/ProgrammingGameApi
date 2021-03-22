namespace ProgrammingGameApi.Services.HelperClasses
{
    /// <summary>
    /// Rextester snippet item model
    /// </summary>
    public class RextesterSnippetItem
    {
        /// <summary>
        /// Language code 
        /// </summary>
        public int LanguageChoice { get; set; }

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
