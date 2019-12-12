using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDrivingMVC.Migrations
{
    public partial class ActivityTypeBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityType_Vehicle_VehicleId",
                table: "ActivityType");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "ActivityType",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookingLogId",
                table: "ActivityType",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType",
                column: "BookingLogId",
                principalTable: "BookingLog",
                principalColumn: "BookingLogId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityType_Vehicle_VehicleId",
                table: "ActivityType",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityType_Vehicle_VehicleId",
                table: "ActivityType");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "ActivityType",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingLogId",
                table: "ActivityType",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityType_BookingLog_BookingLogId",
                table: "ActivityType",
                column: "BookingLogId",
                principalTable: "BookingLog",
                principalColumn: "BookingLogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityType_Vehicle_VehicleId",
                table: "ActivityType",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
