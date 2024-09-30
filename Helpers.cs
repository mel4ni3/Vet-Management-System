using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Management_Tool
{
    public class Helpers
    {
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
    }
}