using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class PaymentDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 19, 39, 1, 121, DateTimeKind.Utc).AddTicks(3972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 18, 14, 4, 87, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Bills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 18, 14, 4, 87, DateTimeKind.Utc).AddTicks(5335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 19, 39, 1, 121, DateTimeKind.Utc).AddTicks(3972));
        }
    }
}
