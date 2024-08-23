using Microsoft.EntityFrameworkCore;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Data;

public class ToDoListContext(DbContextOptions<ToDoListContext> options)
 : DbContext(options)
{
    public DbSet<Quest> Quests => Set<Quest>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new() { Id = 1, Name = "Daily" },
            new() { Id = 2, Name = "Homework" },
            new() { Id = 3, Name = "Self-development" },
            new() { Id = 4, Name = "Food/Nutrition" },
            new() { Id = 5, Name = "Hobby" },
            new() { Id = 6, Name = "Friends" }
        );
    }
}
