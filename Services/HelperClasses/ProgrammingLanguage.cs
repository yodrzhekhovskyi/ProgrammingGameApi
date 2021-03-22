namespace ProgrammingGameApi.Services.HelperClasses
{
    /// <summary>
    /// Helper object which contains programming language code and name
    /// </summary>
    public class ProgrammingLanguage
    {
        /// <summary>
        /// Name of programming language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Code of programming language
        /// </summary>
        public SnippetLanguageCode SnippetLanguageCode { get; set; }
    }
}
