namespace MeChallenge.Application.Product.GetList
{
    using Domain.AggregatesModels.Product;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProductsListQueryHandler : IQueryHandler<GetProductsListQuery, List<ListOfProducstsDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ListOfProducstsDto>> Handle(GetProductsListQuery request,
            CancellationToken cancellationToken)
        {
            List<Product> productsList = await _productRepository.GetAllAsync();

            return productsList.Select(product => new ListOfProducstsDto
            {
                Produto = product.ProductId.Value,
                Nome = product.Name,
                Descricao = product.Description,
                PrecoUnitario = product.UnitValue
            }).ToList();
        }
    }
}