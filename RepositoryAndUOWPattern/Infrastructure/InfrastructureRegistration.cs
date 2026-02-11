using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void RegisterInfra(this IServiceCollection collection, string connection)
        {
            collection.AddDbContext<EFContext>(options => options.UseSqlServer(connection),
                                                                contextLifetime: ServiceLifetime.Scoped);


            collection.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));

            collection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
