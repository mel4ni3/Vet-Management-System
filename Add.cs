using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Management_Tool
{
    public class Add
    {
        // ADD CLINIC
        public static void AddClinic()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter Clinic name:");
                string clinicName = Console.ReadLine() ?? "";

                //   string phoneNumber;

                string phoneNumber = Helpers.GetPhoneNumber();

                Console.WriteLine("Enter Clinic Address:");
                string address = Console.ReadLine() ?? "";

                //var manager = context.Employees.FirstOrDefault(c => c.EmployeeId == managerId);
                //if (manager == null)
                //{
                //    Console.WriteLine("That manager does not exist.");
                //    return;
                //}

                var clinic = new Clinic
                {
                    ClinicName = clinicName,
                    PhoneNum = phoneNumber,
                    Address = address,
                    //ManagerEmployeeId = managerId
                };

                context.Clinics.Add(clinic);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Clinic added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



        // ADD EMPLOYEE
        public static void AddEmployee()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter Employee first name:");
                string firstName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter Employee last name:");
                string lastName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter the address for this Employee:");
                string address = Console.ReadLine() ?? "";

                string phoneNumber = Helpers.GetPhoneNumber();

                DateOnly actualDOB = Helpers.GetValidDate("Enter Employee Date of Birth (YYYY-MM-DD): ");

                Console.Write("Enter Employee Position: ");
                string position = Console.ReadLine() ?? "";

                Console.Write("Enter Employee Salary: ");
                int salary = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Enter the ID of the clinic they work at : ");
                int clinicId = int.Parse(Console.ReadLine() ?? "");

                var clinic = context.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
                if (clinic == null)
                {
                    Console.WriteLine("Clinic not found.");
                    return;
                }

                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    EmployeePhone = phoneNumber,
                    DOB = actualDOB,
                    Position = position,
                    Salary = salary,
                    ClinicId = clinicId
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Employee added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



        // ADD OWNER
        public static void AddOwner()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter Owner first name:");
                string firstName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter Owner last name:");
                string lastName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter the address for this Owner:");
                string address = Console.ReadLine() ?? "";

                string phoneNumber = Helpers.GetPhoneNumber();

                Console.Write("Enter the ID of the clinic they attend : ");
                int clinicId = int.Parse(Console.ReadLine() ?? "");

                var clinic = context.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
                if (clinic == null)
                {
                    Console.WriteLine("Clinic not found.");
                    return;
                }

                var owner = new Owner
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    OwnerPhone = phoneNumber,
                    ClinicId = clinicId
                };

                context.Owners.Add(owner);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Owner added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



        // ADD PET
        public static void AddPet()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter Pet Name:");
                string petName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter Pet Species:");
                string species = Console.ReadLine() ?? "";

                Console.WriteLine("Enter Pet Breed:");
                string breed = Console.ReadLine() ?? "";

                Console.WriteLine("Enter Pet Color:");
                string color = Console.ReadLine() ?? "";

                DateOnly actualDOB = Helpers.GetValidDate("Enter Pet Date of Birth (YYYY-MM-DD): ");

                Console.Write("Enter the ID of the Pet Owner : ");
                int ownerID = int.Parse(Console.ReadLine() ?? "");

                var owner = context.Owners.FirstOrDefault(o => o.OwnerId == ownerID);
                if (owner == null)
                {
                    Console.WriteLine("Owner not found.");
                    return;
                }

                Console.Write("Enter the ID of the Clinic that cares for this pet: ");
                int clinicId = int.Parse(Console.ReadLine() ?? "");

                var clinic = context.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
                if (clinic == null)
                {
                    Console.WriteLine("Clinic not found.");
                    return;
                }

                var pet = new Pet
                {
                    Name = petName,
                    Species = species,
                    Breed = breed,
                    Color = color,
                    DOB = actualDOB,
                    OwnerId = ownerID,
                    ClinicId = clinicId
                };

                context.Pets.Add(pet);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Pet added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



        // ADD EXAM
        public static void AddExamination()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter reason for visit:");
                string complaint = Console.ReadLine() ?? "";

                Console.Write("Enter today's date (YYYY-MM-DD): ");
                string date = Console.ReadLine() ?? "";
                DateOnly actualDate = DateOnly.Parse(date);

                Console.WriteLine("Action taken during visit:");
                string actionTaken = Console.ReadLine() ?? "";

                Console.WriteLine("Enter the pet ID:");
                string? petId = (Console.ReadLine() ?? "");

                // add input validation for if the id is not in the correct format
                // keep prompting until they enter an integer
                while (true)
                {
                    if (!int.TryParse(petId, out int result))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for the Pet ID.");
                        petId = (Console.ReadLine() ?? "");
                    }
                    else
                    {
                        break;
                    }

                }

                var pet = context.Pets.FirstOrDefault(c => c.PetId == int.Parse(petId));
                if (pet == null)
                {
                    Console.WriteLine("Pet not found.");
                    return;
                }

                Console.WriteLine("Enter the employee ID:");
                int employeeId = int.Parse(Console.ReadLine() ?? "");

                var employee = context.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                Console.Write("Enter the ID of the clinic they attend : ");
                int clinicId = int.Parse(Console.ReadLine() ?? "");

                var clinic = context.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
                if (clinic == null)
                {
                    Console.WriteLine("Clinic not found.");
                    return;
                }

                var examination = new Examination
                {
                    ChiefComplaint = complaint,
                    Date = actualDate,
                    ActionTaken = actionTaken,
                    PetId = int.Parse(petId),
                    EmployeeId = employeeId,
                    ClinicId = clinicId
                };

                context.Examinations.Add(examination);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Examinations added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}