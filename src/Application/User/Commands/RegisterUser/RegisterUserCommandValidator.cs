using FluentValidation;

namespace Application.User.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una direccion valida 'example@example.com'.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("El campo Usuario no puede estar vacio.")
                .MaximumLength(80).WithMessage("El campo Usuario no debe exceder los {MaxLength} caracteres.");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("El campo {PropertyName} no puede estar vacio y debe contener al menos 6 caracteres, una letra mayuscula 'A-Z', un numero '0-9' y un caracter especial '/*+%-$'.")
                .MaximumLength(50).WithMessage("El campo Constraseña no debe exceder los {MaxLength} caracteres.");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty()
                .WithMessage("El campo Apellido no puede estar vacio y debe contener al menos 6 caracteres, una letra mayuscula 'A-Z', un numero '0-9' y un caracter especial '/*+%-$'.")
                .MaximumLength(50).WithMessage("El campo Constraseña no debe exceder los {MaxLength} caracteres.")
                .Equal(p => p.Password).WithMessage("{PropertyName} debe ser igual a Password.");
        }
    }
}