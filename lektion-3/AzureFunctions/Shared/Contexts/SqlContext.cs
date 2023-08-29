using Microsoft.EntityFrameworkCore;
using Shared.Models.Entities;

namespace Shared.Contexts;

public class SqlContext : DbContext
{
    public SqlContext()
    {
    }

    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
}
