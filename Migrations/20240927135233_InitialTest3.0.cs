using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet_Management_Tool.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Clinics_ClinicId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Employees_EmployeeId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clinics_ClinicId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Pets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Owners",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Examinations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Examinations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Examinations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Clinics_ClinicId",
                table: "Examinations",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Employees_EmployeeId",
                table: "Examinations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clinics_ClinicId",
                table: "Pets",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Clinics_ClinicId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Employees_EmployeeId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clinics_ClinicId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Owners",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinics_ClinicId",
                table: "Employees",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Clinics_ClinicId",
                table: "Examinations",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Employees_EmployeeId",
                table: "Examinations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clinics_ClinicId",
                table: "Pets",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
