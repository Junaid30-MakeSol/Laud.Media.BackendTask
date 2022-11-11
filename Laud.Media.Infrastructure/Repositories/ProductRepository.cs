using Laud.Media.Domain.Entities.Product;
using Laud.Media.Domain.Interfaces;
using Laud.Media.Infrastructure.Persistence;

namespace Laud.Media.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //public ProductEntity GetByGuid(Guid guId)
        //{
        //    return _context.Set<ProductEntity>().Where(x => x.Guid == guId).FirstOrDefault();
        //}

    }
}
