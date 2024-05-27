using Microsoft.EntityFrameworkCore;
using Todo.Crud.Web.Domain.Entities;

namespace Todo.Crud.Web.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<TodoEntity> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
