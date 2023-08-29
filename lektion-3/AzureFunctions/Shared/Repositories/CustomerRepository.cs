using Shared.Contexts;
using Shared.Models.Entities;

namespace Shared.Repositories;

public class CustomerRepository : Repository<CustomerEntity, SqlContext>
{
    public CustomerRepository(SqlContext context) : base(context)
    {
    }
}
