using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static void RegisterApplication(this IServiceCollection collection)
        {
            collection.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
