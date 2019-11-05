
using FluentValidation;

namespace CLI.Tutorial.Validations
{
    public class ProgramOptionValidator : AbstractValidator<Options.ProgramOptions>
    {
        public ProgramOptionValidator()
        {
            RuleFor(o => o.Password).MinimumLength(5);
            RuleFor(o => o.Username).MinimumLength(5);
        }
    }
}
