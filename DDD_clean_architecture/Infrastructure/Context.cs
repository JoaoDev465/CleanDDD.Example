using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD_clean_architecture.Infrastructure;

public class Context: DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<CarsFactory> Cars { get; set; }
}