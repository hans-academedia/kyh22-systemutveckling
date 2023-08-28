using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
