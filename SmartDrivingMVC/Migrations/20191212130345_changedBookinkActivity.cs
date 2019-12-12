using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDrivingMVC.Migrations
{
    public partial class changedBookinkActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType");

            migrationBuilder.DropIndex(
                name: "IX_ActivityType_BookingLogId",
                table: "ActivityType");

            migrationBuilder.DropColumn(
                name: "BookingLogId",
                table: "ActivityType");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeId",
                table: "BookingLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingLog_ActivityTypeId",
                table: "BookingLog",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingLog_ActivityType_ActivityTypeId",
                table: "BookingLog",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingLog_ActivityType_ActivityTypeId",
                table: "BookingLog");

            migrationBuilder.DropIndex(
                name: "IX_BookingLog_ActivityTypeId",
                table: "BookingLog");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "BookingLog");

            migrationBuilder.AddColumn<int>(
                name: "BookingLogId",
                table: "ActivityType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityType_BookingLogId",
                table: "ActivityType",
                column: "BookingLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType",
                column: "BookingLogId",
                principalTable: "BookingLog",
                principalColumn: "BookingLogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
