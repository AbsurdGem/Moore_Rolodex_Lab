using System;
using System.Collections.Generic;

namespace MooreRolodexLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("     Week 2 – Rolodex Application (Polymorphism)");
            Console.WriteLine("     Developer: Morgan Moore");
            Console.WriteLine("====================================================\n");

            ContactManager manager = new();
            manager.SeedSampleData();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 – Display all contacts");
                Console.WriteLine("2 – Display contacts by last initial");
                Console.WriteLine("0 – Exit");
                Console.Write("Choice: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        ShowContacts(manager.GetAllContacts());
                        break;

                    case "2":
                        Console.Write("Enter a letter: ");
                        char letter = Console.ReadKey().KeyChar;
                        Console.WriteLine("\n");
                        ShowContacts(manager.GetContactsByLastInitial(letter));
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ShowContacts(List<IContactDisplay> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine(" - " + contact.GetSummaryLine());
            }
        }
    }
}
