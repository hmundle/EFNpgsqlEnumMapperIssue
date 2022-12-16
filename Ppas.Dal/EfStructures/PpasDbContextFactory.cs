using Microsoft.EntityFrameworkCore.Design;

namespace Ppas.Dal.EfStructures;

public class PpasDbContextFactory : IDesignTimeDbContextFactory<PpasDbContext>
{
    public PpasDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PpasDbContext>();
        var connectionString = @"Host=localhost;Username=postgres;Port=5433;Password=DummyDummy;Database=TestDB";
        optionsBuilder.UseNpgsql(PpasDbContext.BuildDataSource(connectionString), x => x.MigrationsHistoryTable("ef_migrations_history", "migration"))
            .UseSnakeCaseNamingConvention();
        Console.WriteLine($"The connection string is: {connectionString}");
        return new PpasDbContext(optionsBuilder.Options);
    }
}
