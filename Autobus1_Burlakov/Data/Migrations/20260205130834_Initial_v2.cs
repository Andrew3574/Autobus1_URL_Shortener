using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autobus1_Burlakov.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CONSTRAINT_1",
                table: "urlsdata",
                sql: "PassageCounter >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CONSTRAINT_1",
                table: "urlsdata");
        }
    }
}
