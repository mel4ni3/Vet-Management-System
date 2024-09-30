using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

public static class Program
{
    public static void Main()
    {
        Console.Clear();

        // Begin interaction loop
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n|----------------------------------------------------------------|");
            Console.WriteLine("| Welcome to Veterinary Clinic Management System. Please select: |");
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("| 1 | ➕  ADD DATA                                               |");
            //Console.WriteLine("2 | ✏️  UPDATE");
            Console.WriteLine("| 2 | 🗑️  DELETE DATA                                            |");
            Console.WriteLine("| 3 | 👁️  VIEW DATA                                              |");
            Console.WriteLine("| Q | ❌  QUIT APPLICATION                                       |");
            Console.WriteLine("|----------------------------------------------------------------|\n");

            var input = Console.ReadKey(intercept: true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    ShowAddMenu();
                    break;
                //case ConsoleKey.D2:
                //    ShowUpdateMenu();
                //    break;
                case ConsoleKey.D2:
                    ShowDeleteMenu();
                    break;
                case ConsoleKey.D3:
                    ViewDataMenu();
                    break;
                case ConsoleKey.Q:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid selection. Try again.");
                    break;
            }
        }
    }


    // ############ Menu Functions ############

    // Function to display the Add menu
    public static void ShowAddMenu()
    {
        Console.WriteLine("\n[➕ ADD DATA] Please select: ");
        Console.WriteLine("1 - 👥 Add Employee");
        Console.WriteLine("2 - 🙍 Add Owner");
        Console.WriteLine("3 - 🐶 Add Pet");
        Console.WriteLine("4 - 😷 Add Examination");
        Console.WriteLine("5 - 🏥 Add Clinic");

        var addInput = Console.ReadKey(intercept: true).Key;
        switch (addInput)
        {
            case ConsoleKey.D1:
                AddEmployee();
                break;
            case ConsoleKey.D2:
                AddOwner();
                break;
            case ConsoleKey.D3:
                AddPet();
                break;
            case ConsoleKey.D4:
                AddExamination();
                break;
            case ConsoleKey.D5:
                AddClinic();
                break;
            default:
                Console.WriteLine("\nInvalid selection. Try again.");
                break;
        }
    }

    // Function to display the Update menu
    public static void ShowUpdateMenu()
    {
        Console.WriteLine("\nSelect an option to Update: ");
        Console.WriteLine("1 - Update Employee");
        Console.WriteLine("2 - Update Owner");
        Console.WriteLine("3 - Update Pet");
        Console.WriteLine("4 - Update Examination");
        Console.WriteLine("5 - Update Clinic");

        var updateInput = Console.ReadKey(intercept: true).Key;
        switch (updateInput)
        {
            case ConsoleKey.D1:
                //UpdateEmployee();
                break;
            case ConsoleKey.D2:
                //UpdateOwner();
                break;
            case ConsoleKey.D3:
                //UpdatePet();
                break;
            case ConsoleKey.D4:
                //UpdateExamination();
                break;
            case ConsoleKey.D5:
                //UpdateClinic();
                break;
            default:
                Console.WriteLine("\nInvalid selection. Try again.");
                break;
        }
    }

    // Function to display the Delete menu
    public static void ShowDeleteMenu()
    {
        Console.WriteLine("\nSelect an option to Delete: ");
        Console.WriteLine("1 - Delete Employee");
        Console.WriteLine("2 - Delete Owner");
        Console.WriteLine("3 - Delete Pet");
        Console.WriteLine("4 - Delete Examination");
        Console.WriteLine("5 - Delete Clinic");

        var deleteInput = Console.ReadKey(intercept: true).Key;
        switch (deleteInput)
        {
            case ConsoleKey.D1:
                DeleteEmployee();
                break;
            case ConsoleKey.D2:
                DeleteOwner();
                break;
            case ConsoleKey.D3:
                DeletePet();
                break;
            case ConsoleKey.D4:
                DeleteExamination();
                break;
            case ConsoleKey.D5:
                DeleteClinic();
                break;
            default:
                Console.WriteLine("\nInvalid selection. Try again.");
                break;
        }
    }
    public static void ViewDataMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n|---------------------------------------|");
            Console.WriteLine("| What data would you like to view?:    |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("| 1 | 🏥 Clinics                        |");
            Console.WriteLine("| 2 | 👥 Employees                      |");
            Console.WriteLine("| 3 | 🙍 Owners                         |");
            Console.WriteLine("| 4 | 🐶 Pets                           |");
            Console.WriteLine("| 5 | 😷 Examinations                   |");
            Console.WriteLine("| Q | 🔙 Return to Main Menu            |");
            Console.WriteLine("|---------------------------------------|\n");

            var input = Console.ReadKey(intercept: true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    ViewClinics();
                    break;
                case ConsoleKey.D2:
                    ViewEmployees();
                    break;
                case ConsoleKey.D3:
                    ViewOwners();
                    break;
                case ConsoleKey.D4:
                    ViewPets();
                    break;
                case ConsoleKey.D5:
                    ViewExaminations();
                    break;
                case ConsoleKey.Q:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid selection. Try again.");
                    break;
            }
        }
    }

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

    // ############ HELPERS ############

    public static string GetPhoneNumber()
    {
        while (true)
        {
            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine() ?? "";


            if (!(phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid phone number. Please enter a 10-digit phone number. ");
            }
            else
            {
                return phoneNumber;
            }

        }
    }

    // Function to get a valid date from user input
    public static DateOnly GetValidDate(string prompt)
    {
        DateOnly validDate = new DateOnly();
        bool isValid = false;

        while (!isValid)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine() ?? "";

            if (DateOnly.TryParseExact(userInput, "yyyy-MM-dd", out validDate))
            {
                validDate = DateOnly.Parse(userInput);
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
            }
        }

        return validDate;
    }

    // ############ ADD/CREATE ############
    public static void AddClinic()
    {
        using (var context = new VetDbContext())
        {
            Console.WriteLine("Enter Clinic name:");
            string clinicName = Console.ReadLine() ?? "";

            //   string phoneNumber;

            string phoneNumber = GetPhoneNumber();

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
            Console.WriteLine("Clinic added successfully.");
        }
    }


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

            string phoneNumber = GetPhoneNumber();

            DateOnly actualDOB = GetValidDate("Enter Employee Date of Birth (YYYY-MM-DD): ");

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
            Console.WriteLine("Employee added successfully.");
        }
    }

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

            string phoneNumber = GetPhoneNumber();

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
            Console.WriteLine("Owner added successfully.");
        }
    }

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

            DateOnly actualDOB = GetValidDate("Enter Pet Date of Birth (YYYY-MM-DD): ");

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

            var clinic = context.Clinics.FirstOrDefault(c => c.ClinicId== clinicId);
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
            Console.WriteLine("Pet added successfully.");
        }
    }

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
            Console.WriteLine("Examinations added successfully.");
        }
        }
        //public static void ViewData()
        //{
        //    using (var context = new VetDbContext())
        //    {
        //        //// Display Clinic
        //        Console.WriteLine("\nClinics:");
        //        var clinics = context.Clinics
        //                            .OrderBy(c => c.ClinicId)
        //                            .ToList();

        //        foreach (var clinic in clinics)
        //        {
        //            Console.WriteLine($"{clinic.ClinicId}: {clinic.ClinicName} {clinic.PhoneNum}, Adress: {clinic.Address}");
        //        }

        //        // Display Employeees
        //        Console.WriteLine("\nEmployees:");
        //        var employees = context.Employees
        //                            .Include(t => t.Clinic)  // Include Department for Teachers
        //                            .OrderBy(t => t.EmployeeId)
        //                            .ToList();

        //        foreach (var employee in employees)
        //        {
        //            Console.WriteLine($"{employee.EmployeeId}: {employee.FirstName} {employee.LastName}, Address: {employee.Address}, Phone #: {employee.EmployeePhone}, DOB: {employee.DOB}, Position: {employee.Position}, Clinic: {employee.Clinic?.ClinicName ?? "Unemployed"}, Salary: {employee.Salary}");
        //        }

        //        // Display Owner
        //        Console.WriteLine("\nOwner:");
        //        var owners = context.Owners
        //                            .Include(c => c.Clinic)  // Include Department for Courses
        //                                                     //.Include(c => c.Teachers)Clinic// Include Teachers for each Course
        //                            .OrderBy(e => e.OwnerId)
        //                            .ToList();

        //        foreach (var owner in owners)
        //        {
        //            Console.WriteLine($"{owner.OwnerId}: {owner.FirstName} {owner.LastName}, Address: {owner.Address}, Phone #: {owner.OwnerPhone}, Clinic: {owner.Clinic?.ClinicName ?? "NA"}");
        //        }

        //        // Display Pets

        //        Console.WriteLine("\nPets:");
        //        var pets = context.Pets
        //                            .Include(s => s.Owner)
        //                            .Include(c => c.Clinic)
        //                            .OrderBy(s => s.PetId)
        //                            .ToList();

        //        foreach (var pet in pets)
        //        {
        //            Console.WriteLine($"{pet.PetId}: {pet.Name}, Species: {pet.Species}, Breed: {pet.Breed}, Color: {pet.Color}, DOB: {pet.DOB}, Owner: {pet.Owner?.FirstName ?? "No Owner"}, Clinic: {pet.Clinic?.ClinicName ?? "NA"}");
        //        }

        //        // Display Examinations
        //        Console.WriteLine("\nExaminations:");
        //        var exams = context.Examinations
        //                            .Include(e => e.Pet)     // Include Pet for each Examination
        //                            .Include(e => e.Employee) // Include Employee for each Examination
        //                            .Include(e => e.Clinic)  // // Include Clinic for each Examination
        //                            .OrderBy(g => g.ExamId)
        //                            .ToList();

        //        foreach (var exam in exams)
        //        {
        //            Console.WriteLine($"ExamId: {exam.ExamId}, Chief Complaint: {exam.ChiefComplaint}, Action Taken:  {exam.ActionTaken}, Date: {exam.Date}, Pet ID: {exam.PetId}, Pet Name: {exam.Pet.Name}, Employee ID: {exam.EmployeeId}, Employee Name: {exam.Employee.FirstName + " " + exam.Employee.LastName}, Clinic ID: {exam.ClinicId}");
        //        }


        //    }
        //}



        // ############ DELETES ############
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






    // ############ UPDATES ############

}

