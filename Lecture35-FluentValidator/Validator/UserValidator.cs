using FluentValidation;
using Lecture35_FluentValidator.Requests.Users;

namespace Lecture35_FluentValidator.Validator;

public class UserValidator : AbstractValidator<CreateUserRequest>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MinimumLength(3).WithMessage("First name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("First name must be less than 50 characters long.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Last name must be less than 50 characters long.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Age)
            .NotEmpty().WithMessage("Age is required.")
            .GreaterThanOrEqualTo(18).WithMessage("Age must be at least 18.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
    }
}
