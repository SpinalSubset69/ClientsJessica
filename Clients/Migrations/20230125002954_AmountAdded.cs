using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class AmountAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 25, 0, 29, 54, 603, DateTimeKind.Utc).AddTicks(1944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 20, 16, 46, 258, DateTimeKind.Utc).AddTicks(1179));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Bills",
                type: "decimal(30,6)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 20, 16, 46, 258, DateTimeKind.Utc).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 25, 0, 29, 54, 603, DateTimeKind.Utc).AddTicks(1944));
        }
    }
}
