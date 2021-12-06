using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("El campo Titulo no puede estar vacio.")
                .MaximumLength(200).WithMessage("El campo Titulo no debe exceder los {MaxLength} caracteres.")
                .MustAsync(BeUniqueTitle).WithMessage("El titulo ingresado ya existe.");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoItemCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}