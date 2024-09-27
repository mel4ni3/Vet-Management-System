using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vet_Management_Tool.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClinicName = table.Column<string>(type: "text", nullable: false),
                    PhoneNum = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    EmployeePhone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    ClinicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OwnerPhone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ClinicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    ClinicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChiefComplaint = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ActionTaken = table.Column<string>(type: "text", nullable: false),
                    PetId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    ClinicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Examinations_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clinic",
                columns: new[] { "ClinicId", "Address", "ClinicName", "PhoneNum" },
                values: new object[,]
                {
                    { 1, "6253 Park Avenue", "Barry Bonds Pet Care", "5615366410" },
                    { 2, "1800 Martin Luther King Blvd", "Dr.G's Clinic for Critters", "9542638957" },
                    { 3, "96 Carlyle Rd", "Unlucky Pet Health Services", "7623916578" },
                    { 4, "8971 Lake Shore Dr", "South Side Veterinarian Center", "9021013365" },
                    { 5, "9856 San Marino Circle", "Adler Animal Hospital", "3056650819" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "ClinicId", "DOB", "EmployeePhone", "FirstName", "LastName", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, "56 Kimberly Estates", 1, new DateOnly(1998, 3, 28), "5506959506", "Benjamin", "Chodry", "Head Veterinarian", 112000 },
                    { 2, "001 Holly Grove Street", 2, new DateOnly(1982, 9, 27), "4109505899", "Dwayne", "Carter", "Head Veterinarian", 112000 },
                    { 3, "22 Melrose Point", 3, new DateOnly(2002, 11, 8), "5286934578", "Amy", "Greenberg", "Head Veterinarian", 112000 },
                    { 4, "783 Palmetto Park Rd", 4, new DateOnly(1976, 6, 15), "8923672103", "Mike", "Chambers", "Head Veterinarian", 112000 },
                    { 5, "21 Scranton Blvd", 5, new DateOnly(1963, 4, 30), "1569876521", "Jan", "Levinson", "Head Veterinarian", 112000 },
                    { 6, "123 Maple Street", 1, new DateOnly(1990, 7, 12), "3056781234", "Laura", "Smith", "Office Manager", 80000 },
                    { 7, "456 Oak Avenue", 2, new DateOnly(1985, 2, 20), "4071234567", "James", "Johnson", "Office Manager", 80000 },
                    { 8, "789 Pine Road", 3, new DateOnly(1995, 5, 15), "5612345678", "Emily", "Davis", "Office Manager", 80000 },
                    { 9, "321 Birch Lane", 4, new DateOnly(1978, 11, 30), "9548765432", "Michael", "Brown", "Office Manager", 80000 },
                    { 10, "654 Cedar Court", 5, new DateOnly(1988, 8, 25), "7863456789", "Sarah", "Wilson", "Office Manager", 80000 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Address", "ClinicId", "FirstName", "LastName", "OwnerPhone" },
                values: new object[,]
                {
                    { 1, "52 Nawfside Rd", 1, "Kirsnick", "Ball", "9875623358" },
                    { 2, "6842 Hillside Lane", 2, "Jon", "Lun", "5552106838" },
                    { 3, "2318 Mountain Hill Drive", 3, "Alena", "Gleeman", "3736912387" },
                    { 4, "64 Cherry Red Rd", 4, "Rashida", "Crowdstrike", "1475623251" },
                    { 5, "1165 Oceanic Plaza", 5, "Miguel", "Gomez", "2326587769" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Breed", "ClinicId", "Color", "DOB", "Name", "OwnerId", "Species" },
                values: new object[,]
                {
                    { 1, "Shitzu", 1, "White", new DateOnly(2016, 3, 14), "Rex", 1, "Dog" },
                    { 2, "Dalmation", 2, "White", new DateOnly(2022, 2, 10), "Domino", 2, "Dog" },
                    { 3, "Macaw", 3, "Green", new DateOnly(2018, 10, 6), "Timothy", 3, "Parrot" },
                    { 4, "Shorthair", 4, "Grey", new DateOnly(2017, 1, 19), "Cristoff", 4, "Cat" },
                    { 5, "Mamba", 5, "Black", new DateOnly(2019, 5, 26), "Kobe", 5, "Snake" }
                });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "ExamId", "ActionTaken", "ChiefComplaint", "ClinicId", "Date", "EmployeeId", "PetId" },
                values: new object[,]
                {
                    { 1, "Metal screw inserted", "Broken Bone", 1, new DateOnly(2024, 3, 20), 1, 1 },
                    { 2, "Surgery", "Broken Bone", 2, new DateOnly(2023, 3, 20), 2, 2 },
                    { 3, "Metal plate inserted", "Broken Bone", 3, new DateOnly(2022, 11, 30), 3, 3 },
                    { 4, "Prescribed antibiotics", "Avian Flu", 4, new DateOnly(2021, 11, 18), 4, 4 },
                    { 5, "De-worming injection given", "Parasitic infection", 5, new DateOnly(2024, 8, 30), 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClinicId",
                table: "Employees",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ClinicId",
                table: "Examinations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_EmployeeId",
                table: "Examinations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_PetId",
                table: "Examinations",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ClinicId",
                table: "Owners",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ClinicId",
                table: "Pets",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Clinic");
        }
    }
}
