using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autobus1_Burlakov.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "creationDate",
                table: "urlsdata",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_DATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creationDate",
                table: "urlsdata");
        }
    }
}
