using Microsoft.EntityFrameworkCore;
using StajOkulu.Core;
using StajOkulu.Core.Repositories;

namespace StajOkulu.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWitCategory()
        {

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
