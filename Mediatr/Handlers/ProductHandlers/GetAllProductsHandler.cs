using AutoMapper;
using TableDependencyWithSignalR.Mediatr.Queries.ProductQueries;
using TableDependencyWithSignalR.Repositories.Concret;

namespace TableDependencyWithSignalR.Mediatr.Handlers.ProductHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly ProductRepository productRepository;
    private readonly IMapper mapper;
    public GetAllProductsHandler(ProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;   
    }

    public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        mapper.
        throw new NotImplementedException();
    }
}
