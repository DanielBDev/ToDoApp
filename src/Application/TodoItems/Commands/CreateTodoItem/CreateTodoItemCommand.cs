using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<Result<int>>
    {
        public int ListId { get; set; }
        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result<int>(entity.Id);
        }
    }
}