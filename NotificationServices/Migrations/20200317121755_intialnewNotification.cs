using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RPI_Task.Migrations
{
    public partial class intialnewNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.AddColumn<int>(
                name: "target",
                table: "Notification_Logs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "target",
                table: "Notification_Logs");

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notification_logsTBid = table.Column<int>(type: "integer", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true)
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
    }
}
