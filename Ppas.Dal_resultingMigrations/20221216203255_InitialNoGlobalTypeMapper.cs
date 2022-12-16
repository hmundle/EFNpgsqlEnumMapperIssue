using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ppas.Dal.EfStructures.Migrations
{
    /// <inheritdoc />
    public partial class InitialNoGlobalTypeMapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ppas");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:ppas.quadrant_type", "undefined,a,b,c,d");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "ppas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quadrant = table.Column<int>(type: "integer", nullable: false, comment: "Quadrant identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_name",
                schema: "ppas",
                table: "users",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "ppas");
        }
    }
}
