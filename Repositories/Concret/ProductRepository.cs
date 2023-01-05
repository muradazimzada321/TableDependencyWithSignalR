using Dapper;
using System.Data;
using System.Data.SqlClient;
using TableDependencyWithSignalR.Repositories.Abstract;

namespace TableDependencyWithSignalR.Repositories.Concret
{
    public class ProductRepository : IRepository<Product>
    {
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly IConfiguration configuration;

        public async Task<List<Product>> GetAll()
        {

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString"));
            var products = await connection.QueryAsync<Product, Category, Product>("select p.id, p.Name, p.Price, c.Id, c.Name  from products as p inner join categories as c on p.categoryid = c.id",
                (product, category) =>
                {
                    //product.Category = new Category();
                    //product.Category.Id = category.Id;
                    product.Category = category;
                    return product;
                });
                //splitOn:"Id,Name");
            return products.ToList();   
        }
    }
}
