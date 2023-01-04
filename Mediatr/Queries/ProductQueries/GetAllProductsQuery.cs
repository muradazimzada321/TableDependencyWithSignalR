using MediatR;

namespace TableDependencyWithSignalR.Mediatr.Queries.ProductQueries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}
