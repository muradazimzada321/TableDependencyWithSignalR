using Microsoft.AspNetCore.SignalR;
using TableDependencyWithSignalR.Mediatr.Queries.ProductQueries;

namespace TableDependencyWithSignalR.Hubs
{
    public class DashboardHub:Hub 
    {
        private readonly Mediator mediator;
        public DashboardHub(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task SendProducts()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            await Clients.All.SendAsync("ReceiveProducts", products);
        }

    }
}
