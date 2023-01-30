using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 1, 16, 20, 4, 58, 180, DateTimeKind.Utc).AddTicks(4171));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Bills");
        }
    }
}
