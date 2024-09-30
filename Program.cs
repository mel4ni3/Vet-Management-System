using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using Vet_Management_Tool;

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
            Console.WriteLine("| 2 | 🗑️  DELETE DATA                                            |");
            Console.WriteLine("| 3 | 👁️  VIEW DATA                                              |");
            Console.WriteLine("| Q | ❌  QUIT APPLICATION                                       |");
            Console.WriteLine("|----------------------------------------------------------------|\n");

            var input = Console.ReadKey(intercept: true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    Menus.ShowAddMenu();
                    break;
                case ConsoleKey.D2:
                    Menus.ShowDeleteMenu();
                    break;
                case ConsoleKey.D3:
                    Menus.ShowViewMenu();
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