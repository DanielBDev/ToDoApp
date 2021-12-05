using Domain.Common;

namespace Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public string Title { get; set; }
        public bool Done { get; set; }
        public int ListId { get; set; }
        public TodoList List { get; set; } = null;
    }
}