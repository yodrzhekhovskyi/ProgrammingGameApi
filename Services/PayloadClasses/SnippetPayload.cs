using FluentValidation;

namespace ProgrammingGameApi.Services.PayloadClasses
{
    /// <summary>
    /// Snippet's payload data
    /// </summary>
    public class SnippetPayload
    {
        /// <summary>
        /// Snippet language code
        /// </summary>
        public SnippetLanguageCode Code { get; set; }

        /// <summary>
        /// Program code
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Input params
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Compiler arguments
        /// </summary>
        public string CompilerArgs { get; set; }
    }

    /// <summary>
    /// Snippet payload validatiob
    /// </summary>
    public class SnippetPayloadValidator : AbstractValidator<SnippetPayload>
    {
        public SnippetPayloadValidator()
        {
            RuleFor(x => x.Code).IsInEnum();
            RuleFor(x => x.Program).MinimumLength(1);
        }
    }
}
