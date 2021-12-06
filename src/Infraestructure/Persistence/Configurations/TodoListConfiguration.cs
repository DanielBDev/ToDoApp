using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            var list = new TodoList
            {
                Id = 1,
                Title = "Default",
                CreatedBy = "Default"
            };

            builder.HasData(list);
        }
    }
}