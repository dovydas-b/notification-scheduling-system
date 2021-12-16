using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace notification_scheduling_system.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    MarketType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SendingDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSchedules_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSchedules_CompanyId",
                table: "NotificationSchedules",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationSchedules");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
