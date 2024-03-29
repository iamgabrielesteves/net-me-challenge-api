﻿namespace MeChallenge.Domain.AggregatesModels.Product
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<List<Product>> GetByIdsAsync(List<ProductId> ids);

        Task<List<Product>> GetAllAsync();
    }
}