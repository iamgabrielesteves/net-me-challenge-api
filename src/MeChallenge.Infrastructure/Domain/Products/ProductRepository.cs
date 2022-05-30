namespace MeChallenge.Infrastructure.Domain.Products
{
    using Database;
    using MeChallenge.Domain.AggregatesModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly MeChallengeContext _context;

        public ProductRepository(MeChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Product>> GetByIdsAsync(List<ProductId> ids)
        {
            return await _context
                .Products
                .Where(x => ids.Contains(x.ProductId)).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context
                .Products
                .ToListAsync();
        }
    }
}