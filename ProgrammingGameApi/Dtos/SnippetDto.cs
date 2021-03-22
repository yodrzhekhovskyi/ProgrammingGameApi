using ProgrammingGameApi.Services;

namespace ProgrammingGameApi.Dtos
{
    public class SnippetDto
    {
        public SnippetLanguageCode Code { get; set; }
        public string Program { get; set; }
        public string Input { get; set; }
        public string CompilerArgs { get; set; }
    }
}
