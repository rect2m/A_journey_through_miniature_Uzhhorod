using Microsoft.EntityFrameworkCore;

namespace A_journey_through_miniature_Uzhhorod.Database
{
    public interface IAppDbContextFactory
    {
        AppDbContext CreateContext();
    }

    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public AppDbContextFactory(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public AppDbContext CreateContext() => _factory.CreateDbContext();
    }
}
