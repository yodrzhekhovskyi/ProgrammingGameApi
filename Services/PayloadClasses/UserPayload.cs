using FluentValidation;

namespace ProgrammingGameApi.Services.PayloadClasses
{
    /// <summary>
    /// User's payload data
    /// </summary>
    public class UserPayload
    {
        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User password confirmation
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// User payloads validator
    /// </summary>
    public class UserPayloadValidator : AbstractValidator<UserPayload>
    {
        public UserPayloadValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
            RuleFor(x => x.ConfirmPassword)
                .Must((model, field) => model.Password == field)
                .WithMessage("Passwords missmatch")
                .MinimumLength(1)
                .When(x => !string.IsNullOrEmpty(x.ConfirmPassword));
            RuleFor(x => x.Email).MinimumLength(1);
        }
    }
}
