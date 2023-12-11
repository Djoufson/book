using Catalog.API.Infra.Data;
using Catalog.API.Infrastructure;
using Shared.EF.Database;

namespace Catalog.API.Extension;

internal static class Extensions
{
    public static IHostApplicationBuilder AddCatalogServices(this IHostApplicationBuilder builder, IConfiguration configuration)
    {
        // The commented code was used without Aspire
        // services.AddDbContext<CatalogDbContext>(opt =>
        // {
        //     opt.UseNpgsql(configuration.GetConnectionString("Postgresql"));
        // });

        builder.AddNpgsqlDbContext<CatalogDbContext>("CatalogDb");
        builder.Services.AddMigration<CatalogDbContext, BooksCatalogSeeder>();
        
        builder.Services.AddProblemDetails();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }
}
