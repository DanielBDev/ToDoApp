using Application.TodoILists.Queries.DTOs;
using Application.TodoItems.Commands.CreateTodoItem;
using Application.TodoItems.Queries.DTOs;
using Application.TodoLists.Commands.CreateTodoList;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DTOs

            CreateMap<TodoList, ToDoListDto>();
            CreateMap<TodoItem, ToDoItemDto>();

            #endregion DTOs

            #region Commands

            CreateMap<CreateTodoListCommandHandler, TodoList>();
            CreateMap<CreateTodoItemCommandHandler, TodoItem>();

            #endregion Commands
        }
    }
}