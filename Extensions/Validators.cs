using FluentValidation;
using TestApi.Models;

namespace TestApi.Validators;

public class BodyInputValidator : AbstractValidator<BodyInput>
{
  public BodyInputValidator()
  {
    RuleFor(x => x.Input).NotEmpty();
    RuleFor(x => x.Input).Must(x => x.GetType() == typeof(decimal));
  }
}

