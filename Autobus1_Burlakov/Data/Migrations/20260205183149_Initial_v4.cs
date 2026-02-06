using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autobus1_Burlakov.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creationDate",
                table: "urlsdata",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "urlsdata",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                collation: "utf8mb4_uca1400_ai_ci",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_uca1400_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_urlsdata_ShortURL",
                table: "urlsdata",
                column: "ShortURL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_urlsdata_ShortURL",
                table: "urlsdata");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "urlsdata",
                newName: "creationDate");

            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "urlsdata",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValueSql: "''",
                collation: "utf8mb4_uca1400_ai_ci",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_uca1400_ai_ci");
        }
    }
}
