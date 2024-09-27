using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet_Management_Tool.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinic_ClinicId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Clinic_ClinicId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Clinic_ClinicId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clinic_ClinicId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic");

            migrationBuilder.RenameTable(
                name: "Clinic",
                newName: "Clinics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "ClinicId");

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
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clinics_ClinicId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinic_ClinicId",
                table: "Employees",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Clinic_ClinicId",
                table: "Examinations",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Clinic_ClinicId",
                table: "Owners",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clinic_ClinicId",
                table: "Pets",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
