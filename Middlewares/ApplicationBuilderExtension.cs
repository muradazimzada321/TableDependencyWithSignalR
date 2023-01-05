using TableDependencyWithSignalR.Subscriptions;

namespace TableDependencyWithSignalR.Middlewares
{
    public static class ApplicationBuilderExtension
    {
        public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<ProductTableSubscription>();
            service?.SubscribeTableDependency();
            
        }
    }
}
