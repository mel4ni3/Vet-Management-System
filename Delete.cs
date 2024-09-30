using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Management_Tool
{
    public class Delete
    {
        // DELETE PET
        public static void DeletePet()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter the Pet ID of the pet you want to delete:");

                try
                {
                    int petId = int.Parse(Console.ReadLine() ?? "");

                    var existingPet = context.Pets.FirstOrDefault(p => p.PetId == petId);

                    if (existingPet != null)
                    {
                        context.Pets.Remove(existingPet);
                        context.SaveChanges();
                        Console.WriteLine("Pet deleted successfully, sorry for your loss.");
                    }
                    else
                    {
                        Console.WriteLine("Pet not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for the Pet ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }



        // DELETE EMPLOYEE
        public static void DeleteEmployee()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter the Employee ID of the Employee you want to delete:");

                try
                {
                    int employeeId = int.Parse(Console.ReadLine() ?? "");

                    var existingEmployee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

                    if (existingEmployee != null)
                    {
                        context.Employees.Remove(existingEmployee);
                        context.SaveChanges();
                        Console.WriteLine("Employee deleted successfully, sorry for your loss, have fun filling out the paperwork.");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for the Employee ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }



        // DELETE CLINIC
        public static void DeleteClinic()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter the Clinic ID of the Clinic you want to delete:");

                try
                {
                    int clinicID = int.Parse(Console.ReadLine() ?? "");

                    var existingClinic = context.Clinics.FirstOrDefault(c => c.ClinicId == clinicID);

                    if (existingClinic != null)
                    {
                        context.Clinics.Remove(existingClinic);
                        context.SaveChanges();
                        Console.WriteLine("Clinic delete successfully. Tough Economy.");
                    }
                    else
                    {
                        Console.WriteLine("Clinic not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for the Employee ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }



        // DELETE EXAM
        public static void DeleteExamination()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter the Examination ID of the Examination you want to delete:");

                try
                {
                    int examinationID = int.Parse(Console.ReadLine() ?? "");

                    var existingExamination = context.Examinations.FirstOrDefault(e => e.EmployeeId == examinationID);

                    if (existingExamination != null)
                    {
                        context.Examinations.Remove(existingExamination);
                        context.SaveChanges();
                        Console.WriteLine("Examination deleted successfully, see you later!");
                    }
                    else
                    {
                        Console.WriteLine("Examination not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for the Examination ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }



        // DELETE OWNER
        public static void DeleteOwner()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("Enter the Owner ID of the Owner you want to delete:");

                try
                {
                    int ownerID = int.Parse(Console.ReadLine() ?? "");

                    var existingOwner = context.Owners.FirstOrDefault(o => o.OwnerId == o.OwnerId);

                    if (existingOwner != null)
                    {
                        var allPets = context.Pets.Where(p => p.OwnerId == ownerID).ToList();
                        foreach (var pet in allPets)
                        {
                            context.Pets.Remove(pet);
                        }
                        context.Owners.Remove(existingOwner);
                        context.SaveChanges();
                        Console.WriteLine("Owner and associated pets deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Owner not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for the Employee ID.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
