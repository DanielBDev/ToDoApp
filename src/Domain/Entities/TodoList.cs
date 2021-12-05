using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public string Title { get; set; }
        public IList<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}