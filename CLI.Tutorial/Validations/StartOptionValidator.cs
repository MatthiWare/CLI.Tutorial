using FluentValidation;

namespace CLI.Tutorial.Validations
{
    public class StartOptionValidator : AbstractValidator<Options.StartOptions>
    {
        public StartOptionValidator()
        {
            RuleFor(o => o.Port).InclusiveBetween(1000, 30000);
        }
    }
}
