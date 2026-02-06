using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autobus1_Burlakov.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

           
            migrationBuilder.CreateTable(
                name: "urlsdata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullURL = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_uca1400_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PassageCounter = table.Column<int>(type: "int(11)", nullable: false),
                    ShortURL = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: false, defaultValueSql: "''", collation: "utf8mb4_uca1400_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_uca1400_ai_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "urlsdata");
        }
    }
}
