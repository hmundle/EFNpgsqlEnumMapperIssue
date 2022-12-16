using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Ppas.Dal.Configuration;

public static class DalConfiguration
{
    public static IServiceCollection RegisterDalServices(this IServiceCollection services, string connectionString)
    {
        /*await using*/
        var dataSource = PpasDbContext.BuildDataSource(connectionString);

        services.AddDbContext<PpasDbContext>(
            options => options
                .UseNpgsql(dataSource, sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60))
                .UseSnakeCaseNamingConvention()
            );

        return services;
    }
}
