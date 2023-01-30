using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class EmailMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 20, 16, 46, 258, DateTimeKind.Utc).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 19, 39, 1, 121, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 23, 19, 39, 1, 121, DateTimeKind.Utc).AddTicks(3972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 23, 20, 16, 46, 258, DateTimeKind.Utc).AddTicks(1179));
        }
    }
}
