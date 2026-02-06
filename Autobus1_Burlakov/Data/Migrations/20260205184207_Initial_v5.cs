using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autobus1_Burlakov.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "urlsdata",
                type: "char(15)",
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                collation: "utf8mb4_uca1400_ai_ci",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_uca1400_ai_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "urlsdata",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                collation: "utf8mb4_uca1400_ai_ci",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldFixedLength: true,
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_uca1400_ai_ci");
        }
    }
}
