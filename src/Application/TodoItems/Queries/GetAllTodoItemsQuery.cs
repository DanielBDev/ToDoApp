using Application.Common.Interfaces;
using Application.Common.Models;
using Application.TodoItems.Queries.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries
{
    public class GetAllTodoItemsQuery : IRequest<Result<List<ToDoItemDto>>>
    {
        public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, Result<List<ToDoItemDto>>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetAllTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }

            public async Task<Result<List<ToDoItemDto>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.TodoItems
                    .Where(k => k.CreatedBy == _currentUserService.UserId)
                    .ToListAsync(cancellationToken);

                var dto = _mapper.Map<List<ToDoItemDto>>(entity);

                return new Result<List<ToDoItemDto>>(dto);
            }
        }
    }
}