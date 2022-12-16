using Npgsql;

using System.Data.Common;

namespace Ppas.Dal.EfStructures;

public partial class PpasDbContext : DbContext
{
    public PpasDbContext(DbContextOptions<PpasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User>? Users { get; set; }

    public static void RegisterGlobalMappers()
    {
        Console.WriteLine("Going to call: NpgsqlConnection.GlobalTypeMapper.MapEnum<*>()");
        NpgsqlConnection.GlobalTypeMapper.MapEnum<QuadrantType>("ppas.quadrant_type");
    }

    public static DbDataSource BuildDataSource(string connectionString)
    {
        //RegisterGlobalMappers(); // uncomment this, to activate the GlobalTypeMapper
        // Create a data source with the configuration you want:
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.MapEnum<QuadrantType>("ppas.quadrant_type");

        /*await using*/
        return dataSourceBuilder.Build();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API calls go here
        modelBuilder
            .HasPostgresEnum<QuadrantType>("ppas")
            ;

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
