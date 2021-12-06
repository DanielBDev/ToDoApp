using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("El campo Titulo no puede estar vacio.")
                .MaximumLength(200).WithMessage("El campo Titulo no debe exceder los {MaxLength} caracteres.")
                .MustAsync(BeUniqueTitle).WithMessage("El titulo ingresado ya existe.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}