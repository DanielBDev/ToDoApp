using Application.Common.Interfaces;
using Application.Common.Models;
using Application.TodoILists.Queries.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TodoILists.Queries
{
    public class GetAllTodoListsQuery : IRequest<Result<List<ToDoListDto>>>
    {
        public class GetAllTodoListsQueryHandler : IRequestHandler<GetAllTodoListsQuery, Result<List<ToDoListDto>>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetAllTodoListsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }

            public async Task<Result<List<ToDoListDto>>> Handle(GetAllTodoListsQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.TodoLists
                    .Where(k => k.CreatedBy == _currentUserService.UserId)
                    .ToListAsync(cancellationToken);

                var dto = _mapper.Map<List<ToDoListDto>>(entity);

                return new Result<List<ToDoListDto>>(dto);
            }
        }
    }
}