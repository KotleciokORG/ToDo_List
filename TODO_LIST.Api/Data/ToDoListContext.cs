using Microsoft.EntityFrameworkCore;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Data;

public class ToDoListContext(DbContextOptions<ToDoListContext> options)
 : DbContext(options)
{
    public DbSet<Quest> Quests => Set<Quest>();
    public DbSet<Genre> Genres => Set<Genre>();
}
