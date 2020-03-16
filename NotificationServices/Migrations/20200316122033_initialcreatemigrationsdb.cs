using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RPI_Task.Migrations
{
    public partial class initialcreatemigrationsdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Logs_Users_from",
                table: "Notification_Logs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Notification_Logs_from",
                table: "Notification_Logs");

            migrationBuilder.DropColumn(
                name: "target",
                table: "Notification_Logs");

            migrationBuilder.AlterColumn<long>(
                name: "update_at",
                table: "Notification_Logs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "create_at",
                table: "Notification_Logs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "updated_at",
                table: "Notification",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "created_at",
                table: "Notification",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message = table.Column<string>(nullable: true),
                    Notification_logsTBid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.id);
                    table.ForeignKey(
                        name: "FK_Target_Notification_Logs_Notification_logsTBid",
                        column: x => x.Notification_logsTBid,
                        principalTable: "Notification_Logs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Target_Notification_logsTBid",
                table: "Target",
                column: "Notification_logsTBid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Notification_Logs",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Notification_Logs",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "target",
                table: "Notification_Logs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Notification",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Notification",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Logs_from",
                table: "Notification_Logs",
                column: "from");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Logs_Users_from",
                table: "Notification_Logs",
                column: "from",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
