using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Management_Tool
{
    public class View
    {
        // VIEW CLINICS
        public static void ViewClinics()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("\n🏥 Clinics:");
                var clinics = context.Clinics.OrderBy(c => c.ClinicId).ToList();
                foreach (var clinic in clinics)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"{clinic.ClinicId}: {clinic.ClinicName}\n Phone: {clinic.PhoneNum}\n Address: {clinic.Address}");
                }
            }
        }



        // VIEW EMPLOYEES
        public static void ViewEmployees()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("\n👥 Employees:");
                var employees = context.Employees.Include(t => t.Clinic).OrderBy(t => t.EmployeeId).ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"{employee.EmployeeId}: {employee.FirstName} {employee.LastName}\n Address: {employee.Address}\n Phone: {employee.EmployeePhone}\n DOB: {employee.DOB}\n Position: {employee.Position}\n Clinic: {employee.Clinic?.ClinicName ?? "Unemployed"}\n Salary: {employee.Salary}");
                }
            }
        }



        // VIEW OWNERS
        public static void ViewOwners()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("\n🙍 Owners:");
                var owners = context.Owners.Include(c => c.Clinic).OrderBy(e => e.OwnerId).ToList();
                foreach (var owner in owners)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"{owner.OwnerId}: {owner.FirstName} {owner.LastName}\n Address: {owner.Address}\n Phone: {owner.OwnerPhone}\n Clinic: {owner.Clinic?.ClinicName ?? "NA"}");
                }
            }
        }



        // VIEW PETS
        public static void ViewPets()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("\n🐶 Pets:");
                var pets = context.Pets.Include(s => s.Owner).Include(c => c.Clinic).OrderBy(s => s.PetId).ToList();
                foreach (var pet in pets)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"{pet.PetId}: {pet.Name}\n Species: {pet.Species}\n Breed: {pet.Breed}\n Color: {pet.Color}\n DOB: {pet.DOB}\n Owner: {pet.Owner?.FirstName ?? "No Owner"}\n Clinic: {pet.Clinic?.ClinicName ?? "NA"}");
                }
            }
        }



        // VIEW EXAMS
        public static void ViewExaminations()
        {
            using (var context = new VetDbContext())
            {
                Console.WriteLine("\n😷 Examinations:");
                var exams = context.Examinations.Include(e => e.Pet)
                                                .Include(e => e.Employee)
                                                .Include(e => e.Clinic)
                                                .OrderBy(g => g.ExamId).ToList();
                foreach (var exam in exams)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"ExamId: {exam.ExamId}\n Chief Complaint: {exam.ChiefComplaint}\n Action Taken:  {exam.ActionTaken}\n Date: {exam.Date}\n Pet Name: {exam.Pet.Name}\n Employee Name: {exam.Employee.FirstName} {exam.Employee.LastName}\n Clinic: {exam.Clinic?.ClinicName}");
                }
            }
        }
    }
}