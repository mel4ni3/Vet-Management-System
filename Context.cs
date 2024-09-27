using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

public class VetDbContext : DbContext
{
    public DbSet<Clinic> Clinics{ get; set; }
    public DbSet<Pet> Pets{ get; set; }
    public DbSet<Owner> Owners{ get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Examination> Examinations{ get; set; }
    //public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString:
            "Server=localhost;Port=5432;User Id=postgres;Password=password;Database=vet;Include Error Detail=true;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Clinic without ManagerEmployeeId
        modelBuilder.Entity<Clinic>().HasData(
            new Clinic { ClinicId = 1, ClinicName = "Barry Bonds Pet Care", Address = "6253 Park Avenue", PhoneNum = "5615366410" },
            new Clinic { ClinicId = 2, ClinicName = "Dr.G's Clinic for Critters", Address = "1800 Martin Luther King Blvd", PhoneNum = "9542638957" },
            new Clinic { ClinicId = 3, ClinicName = "Unlucky Pet Health Services", Address = "96 Carlyle Rd", PhoneNum = "7623916578" },
            new Clinic { ClinicId = 4, ClinicName = "South Side Veterinarian Center", Address = "8971 Lake Shore Dr", PhoneNum = "9021013365" },
            new Clinic { ClinicId = 5, ClinicName = "Adler Animal Hospital", Address = "9856 San Marino Circle", PhoneNum = "3056650819" }
        );

        // Seed Employeee
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, ClinicId = 1, FirstName = "Benjamin", LastName = "Chodry",Address = "56 Kimberly Estates", EmployeePhone = "5506959506", DOB = new DateOnly(1998,03,28), Position = "Head Veterinarian", Salary = 112000 },
            new Employee { EmployeeId = 2, ClinicId = 2, FirstName = "Dwayne", LastName = "Carter", Address = "001 Holly Grove Street", EmployeePhone = "4109505899", DOB = new DateOnly(1982, 09, 27), Position = "Head Veterinarian", Salary = 112000 },
            new Employee { EmployeeId = 3, ClinicId = 3, FirstName = "Amy", LastName = "Greenberg", Address = "22 Melrose Point", EmployeePhone = "5286934578", DOB = new DateOnly(2002, 11, 08), Position = "Head Veterinarian", Salary = 112000 },
            new Employee { EmployeeId = 4, ClinicId = 4, FirstName = "Mike", LastName = "Chambers", Address = "783 Palmetto Park Rd", EmployeePhone = "8923672103", DOB = new DateOnly(1976, 06, 15), Position = "Head Veterinarian", Salary = 112000 },
            new Employee { EmployeeId = 5, ClinicId = 5, FirstName = "Jan", LastName = "Levinson", Address = "21 Scranton Blvd", EmployeePhone = "1569876521", DOB = new DateOnly(1963, 04, 30), Position = "Head Veterinarian", Salary = 112000 },
            new Employee { EmployeeId = 6, ClinicId = 1, FirstName = "Laura", LastName = "Smith", Address = "123 Maple Street", EmployeePhone = "3056781234", DOB = new DateOnly(1990, 07, 12), Position = "Office Manager", Salary = 80000 },
            new Employee { EmployeeId = 7, ClinicId = 2, FirstName = "James", LastName = "Johnson", Address = "456 Oak Avenue", EmployeePhone = "4071234567", DOB = new DateOnly(1985, 02, 20), Position = "Office Manager", Salary = 80000 },
            new Employee { EmployeeId = 8, ClinicId = 3, FirstName = "Emily", LastName = "Davis", Address = "789 Pine Road", EmployeePhone = "5612345678", DOB = new DateOnly(1995, 05, 15), Position = "Office Manager", Salary = 80000 },
            new Employee { EmployeeId = 9, ClinicId = 4, FirstName = "Michael", LastName = "Brown", Address = "321 Birch Lane", EmployeePhone = "9548765432", DOB = new DateOnly(1978, 11, 30), Position = "Office Manager", Salary = 80000 },
            new Employee { EmployeeId = 10, ClinicId = 5, FirstName = "Sarah", LastName = "Wilson", Address = "654 Cedar Court", EmployeePhone = "7863456789", DOB = new DateOnly(1988, 08, 25), Position = "Office Manager", Salary = 80000 }
        );


        // Seed Owner
        modelBuilder.Entity<Owner>().HasData(
            new Owner { OwnerId = 1, ClinicId = 1, FirstName = "Kirsnick", LastName = "Ball", Address = "52 Nawfside Rd", OwnerPhone = "9875623358"},
            new Owner { OwnerId = 2, ClinicId = 2, FirstName = "Jon", LastName = "Lun", Address = "6842 Hillside Lane", OwnerPhone = "5552106838" },
            new Owner { OwnerId = 3, ClinicId = 3, FirstName = "Alena", LastName = "Gleeman", Address = "2318 Mountain Hill Drive", OwnerPhone = "3736912387" },
            new Owner { OwnerId = 4, ClinicId = 4, FirstName = "Rashida", LastName = "Crowdstrike", Address = "64 Cherry Red Rd", OwnerPhone = "1475623251" },
            new Owner { OwnerId = 5, ClinicId = 5, FirstName = "Miguel", LastName = "Gomez", Address = "1165 Oceanic Plaza", OwnerPhone = "2326587769" }

        );

        // Seed Pet
        modelBuilder.Entity<Pet>().HasData(
           new Pet { PetId = 1, Name = "Rex", DOB = new DateOnly(2016,03,14), Species = "Dog", Breed = "Shitzu", Color = "White", OwnerId = 1, ClinicId = 1 },
           new Pet { PetId = 2, Name = "Domino", DOB = new DateOnly(2022, 02, 10), Species = "Dog", Breed = "Dalmation", Color = "White", OwnerId = 2 ,ClinicId = 2 },
           new Pet { PetId = 3, Name = "Timothy", DOB = new DateOnly(2018, 10, 06), Species = "Parrot", Breed = "Macaw", Color = "Green", OwnerId = 3, ClinicId = 3 },
           new Pet { PetId = 4, Name = "Cristoff", DOB = new DateOnly(2017, 01, 19), Species = "Cat", Breed = "Shorthair", Color = "Grey", OwnerId = 4, ClinicId = 4 },
           new Pet { PetId = 5, Name = "Kobe", DOB = new DateOnly(2019, 05, 26), Species = "Snake", Breed = "Mamba", Color = "Black", OwnerId = 5, ClinicId = 5 }
        );

        // Seed Examination
        modelBuilder.Entity<Examination>().HasData(
            new Examination { ExamId =1, ChiefComplaint = "Broken Bone", Date = new DateOnly(2024, 03, 20), ActionTaken = "Metal screw inserted", PetId =1, EmployeeId = 1, ClinicId = 1 },
            new Examination { ExamId = 2, ChiefComplaint = "Broken Bone", Date = new DateOnly(2023, 03, 20), ActionTaken = "Surgery", PetId = 2, EmployeeId = 2, ClinicId = 2 },
            new Examination { ExamId = 3, ChiefComplaint = "Broken Bone", Date = new DateOnly(2022, 11, 30), ActionTaken = "Metal plate inserted", PetId = 3, EmployeeId = 3, ClinicId = 3 },
            new Examination { ExamId = 4, ChiefComplaint = "Avian Flu", Date = new DateOnly(2021, 11, 18), ActionTaken = "Prescribed antibiotics", PetId = 4, EmployeeId = 4, ClinicId = 4 },
            new Examination { ExamId = 5, ChiefComplaint = "Parasitic infection", Date = new DateOnly(2024, 08, 30), ActionTaken = "De-worming injection given", PetId = 5, EmployeeId = 5 ,ClinicId = 5 }

        );

        //// Seed Grades
        //modelBuilder.Entity<Grade>().HasData(
        //    new Grade { GradeId = 1, StudentId = 1, AssignmentId = 1, Score = 85 },
        //    new Grade { GradeId = 2, StudentId = 2, AssignmentId = 2, Score = 90 },
        //    new Grade { GradeId = 3, StudentId = 3, AssignmentId = 3, Score = 75 },
        //    new Grade { GradeId = 4, StudentId = 4, AssignmentId = 4, Score = 88 }
        //);

        //// Seed relationships for Course-Teacher
        //modelBuilder.Entity<Course>()
        //    .HasMany(c => c.Teachers)
        //    .WithMany(t => t.Courses)
        //    .UsingEntity(j => j.HasData(
        //        new { CoursesCourseId = 1, TeachersTeacherId = 1 },
        //        new { CoursesCourseId = 2, TeachersTeacherId = 2 }
        //    ));

        // Seed relationships for Clinic-Employee
        modelBuilder.Entity<Clinic>()
            // A Clinic can employ many employees
            .HasMany(c => c.Employees)
            .WithOne(e => e.Clinic)
            .HasForeignKey(e => e.ClinicId);

        // Seed relationships for Clinic-Pet
        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.Pets)
            .WithOne(p => p.Clinic)
            .HasForeignKey(p => p.ClinicId);

        // Seed relationships for Examination-Pet
        modelBuilder.Entity<Examination>()
            .HasOne(e => e.Pet)
            .WithMany(p => p.Examinations)
            .HasForeignKey(e => e.PetId);

        // Seed relationships for Examination-Employee
        modelBuilder.Entity<Examination>()
            .HasOne(e => e.Employee)
            .WithMany(emp => emp.Examinations)
            .HasForeignKey(e => e.EmployeeId);

        // Seed relationships for Examination-Clinic
        modelBuilder.Entity<Examination>()
            .HasOne(e => e.Clinic)
            .WithMany(c => c.Examinations)
            .HasForeignKey(e => e.ClinicId);

    }
}
