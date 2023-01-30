using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_RFC_CURP_LastName",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Bills",
                newName: "SecondLastName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 18, 14, 4, 87, DateTimeKind.Utc).AddTicks(5335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 16, 20, 4, 58, 180, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.AddColumn<string>(
                name: "CFDI",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstLastName",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxRegime",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RFC_CURP_FirstLastName_SecondLastName",
                table: "Bills",
                columns: new[] { "RFC", "CURP", "FirstLastName", "SecondLastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_RFC_CURP_FirstLastName_SecondLastName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CFDI",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "FirstLastName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TaxRegime",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "SecondLastName",
                table: "Bills",
                newName: "LastName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 1, 16, 20, 4, 58, 180, DateTimeKind.Utc).AddTicks(4171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 18, 14, 4, 87, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RFC_CURP_LastName",
                table: "Bills",
                columns: new[] { "RFC", "CURP", "LastName" });
        }
    }
}
