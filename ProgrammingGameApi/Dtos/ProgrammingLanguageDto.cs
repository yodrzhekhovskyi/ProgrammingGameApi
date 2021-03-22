using ProgrammingGameApi.Services;

namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// Helper object which contains programming language code and name
    /// </summary>
    public class ProgrammingLanguageDto
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
