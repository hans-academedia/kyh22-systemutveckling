using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Shared.Contexts;

public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
{
    private readonly IConfiguration _configuration;
    public SqlContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlContextFactory()
    {

    }

    public SqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HansMattin-Lassei\\Documents\\azure_localdb.mdf;Integrated Security=True;Connect Timeout=30");

        return new SqlContext(optionsBuilder.Options);
    }
}
