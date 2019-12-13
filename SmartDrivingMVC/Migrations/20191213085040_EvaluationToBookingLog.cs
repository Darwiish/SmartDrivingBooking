using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDrivingMVC.Migrations
{
    public partial class EvaluationToBookingLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_ActivityType_ActivityTypeId",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_ActivityTypeId",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "Evaluation");

            migrationBuilder.AddColumn<int>(
                name: "BookingLogId",
                table: "Evaluation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_BookingLogId",
                table: "Evaluation",
                column: "BookingLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_BookingLog_BookingLogId",
                table: "Evaluation",
                column: "BookingLogId",
                principalTable: "BookingLog",
                principalColumn: "BookingLogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_BookingLog_BookingLogId",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_BookingLogId",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "BookingLogId",
                table: "Evaluation");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeId",
                table: "Evaluation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_ActivityTypeId",
                table: "Evaluation",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_ActivityType_ActivityTypeId",
                table: "Evaluation",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
