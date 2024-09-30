using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Management_Tool
{
    public class Menus
    {
        // Function to display the ADD MENU
        public static void ShowAddMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n|---------------------------------------|");
                Console.WriteLine("| [➕ ADD DATA] Please select:          |");
                Console.WriteLine("|---------------------------------------|");
                Console.WriteLine("| 1 | 👥 Employee                       |");
                Console.WriteLine("| 2 | 🙍 Owner                          |");
                Console.WriteLine("| 3 | 🐶 Pet                            |");
                Console.WriteLine("| 4 | 😷 Examination                    |");
                Console.WriteLine("| 5 | 🏥 Clinic                         |");
                Console.WriteLine("| Q | 🔙 Return to Main Menu            |");
                Console.WriteLine("|---------------------------------------|\n");

                var addInput = Console.ReadKey(intercept: true).Key;
                switch (addInput)
                {
                    case ConsoleKey.D1:
                        Add.AddEmployee();
                        break;
                    case ConsoleKey.D2:
                        Add.AddOwner();
                        break;
                    case ConsoleKey.D3:
                        Add.AddPet();
                        break;
                    case ConsoleKey.D4:
                        Add.AddExamination();
                        break;
                    case ConsoleKey.D5:
                        Add.AddClinic();
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



        // Function to display the DELETE MENU
        public static void ShowDeleteMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n|---------------------------------------|");
                Console.WriteLine("| [🗑️ DELETE DATA] Please select:       |");
                Console.WriteLine("|---------------------------------------|");
                Console.WriteLine("| 1 | 👥 Employee                       |");
                Console.WriteLine("| 2 | 🙍 Owner                          |");
                Console.WriteLine("| 3 | 🐶 Pet                            |");
                Console.WriteLine("| 4 | 😷 Examination                    |");
                Console.WriteLine("| 5 | 🏥 Clinic                         |");
                Console.WriteLine("| Q | 🔙 Return to Main Menu            |");
                Console.WriteLine("|---------------------------------------|\n");

                var deleteInput = Console.ReadKey(intercept: true).Key;
                switch (deleteInput)
                {
                    case ConsoleKey.D1:
                        Delete.DeleteEmployee();
                        break;
                    case ConsoleKey.D2:
                        Delete.DeleteOwner();
                        break;
                    case ConsoleKey.D3:
                        Delete.DeletePet();
                        break;
                    case ConsoleKey.D4:
                        Delete.DeleteExamination();
                        break;
                    case ConsoleKey.D5:
                        Delete.DeleteClinic();
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



        // Function to display the VIEW MENU
        public static void ShowViewMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n|---------------------------------------|");
                Console.WriteLine("| [👁️ VIEW DATA] Please select:         |");
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
                        View.ViewClinics();
                        break;
                    case ConsoleKey.D2:
                        View.ViewEmployees();
                        break;
                    case ConsoleKey.D3:
                        View.ViewOwners();
                        break;
                    case ConsoleKey.D4:
                        View.ViewPets();
                        break;
                    case ConsoleKey.D5:
                        View.ViewExaminations();
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
    }
}