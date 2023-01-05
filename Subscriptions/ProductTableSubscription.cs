using System;
using TableDependency.SqlClient;
using TableDependencyWithSignalR.Hubs;

namespace TableDependencyWithSignalR.Subscriptions
{
    public class ProductTableSubscription
    {
        SqlTableDependency<Product>? tableDependency;
        private readonly IConfiguration configuration;
        private readonly DashboardHub dashboardHub;

        public ProductTableSubscription(IConfiguration configuration, DashboardHub dashboardHub)
        {
            this.configuration = configuration;
            this.dashboardHub = dashboardHub;
        }
        
        public async Task SubscribeTableDependency()
        {
            tableDependency = new SqlTableDependency<Product>(configuration.GetConnectionString("DefaultConnectionString"), "Products");
            tableDependency.OnChanged += TableDependency_OnChangedAsync;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Stop();
            tableDependency.Start();
            await Task.CompletedTask;
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependencyError: {e.Error.Message}");
        }

        private async void TableDependency_OnChangedAsync(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if(e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await dashboardHub.SendProducts();
            }
            
        }
    }
}
