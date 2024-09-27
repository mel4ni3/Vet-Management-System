using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

public class Clinic
{
    public int ClinicId { get; set; }
    [Required]
    public string ClinicName { get; set; } = null!;
    [Required]
    [MaxLength(10)]
    public string PhoneNum { get; set; } = null!;
    public string Address { get; set; } = null!;

    //// Foreign Key to Employee entity for the manager
    //public int ManagerEmployeeId{ get; set; }

    //// Navigation properties
    //[ForeignKey(nameof(ManagerEmployeeId))]
    //public Employee Manager { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();


}

public class Employee
{
    [Required]
    public int EmployeeId { get; set; } // Primary Key

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    [MaxLength(10)]
    public string EmployeePhone { get; set; } = null!;

    public DateOnly DOB { get; set; }

    public string Position { get; set; } = null!;

    public int Salary { get; set; }

    // Foreign Key to Clinic entity
    public int? ClinicId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ClinicId))]
    public Clinic Clinic { get; set; } = null!;

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}

public class Owner
{
    [Required]
    public int OwnerId { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    [MaxLength(10)]
    public string OwnerPhone { get; set; } = null!;

    // Foreign Key to Clinic entity
    public int? ClinicId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ClinicId))]
    public Clinic Clinic { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}

public class Pet
{
    [Required]
    public int PetId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public string Color { get; set; } = null!;
    public DateOnly DOB { get; set; }

    // Foreign Key to Owner
    public int? OwnerId { get; set; }

    // Navigation property for Owner
    [ForeignKey(nameof(OwnerId))]
    public Owner Owner { get; set; } = null!;

    public int? ClinicId { get; set; }

    // Navigation property for Clinic
    [ForeignKey(nameof(ClinicId))]
    public Clinic Clinic { get; set; } = null!;

    // Navigation properties
    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}

// IDK IF WE R STILL DOING THIS TABLE BUT...
public class Examination
{
    [Key]
    [Required]
    public int ExamId { get; set;}

    [Required]
    public string ChiefComplaint {  get; set; } = null!;
    
    [Required]
    public DateOnly Date {  get; set; }

    [Required]
    public string ActionTaken { get; set; } = null!;

    public int? PetId { get; set;}

    [ForeignKey(nameof(PetId))]
    public Pet Pet { get; set; } = null!;

    public int? EmployeeId {  get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;

    public int? ClinicId { get; set; }

    [ForeignKey(nameof(ClinicId))]
    public Clinic Clinic { get; set; } = null!;
}





