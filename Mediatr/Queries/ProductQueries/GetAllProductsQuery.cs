global using  MediatR;
global using TableDependencyWithSignalR.Models;
namespace TableDependencyWithSignalR.Mediatr.Queries.ProductQueries;
public class GetAllProductsQuery : IRequest<List<Product>>
{
}
