using AutoMapper;
using TableDependencyWithSignalR.Mediatr.Queries.ProductQueries;
using TableDependencyWithSignalR.Repositories.Concret;

namespace TableDependencyWithSignalR.Mediatr.Handlers.ProductHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly ProductRepository productRepository;
    public GetAllProductsHandler(ProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {

        var products = await productRepository.GetAll();
        return products;
    }
}
