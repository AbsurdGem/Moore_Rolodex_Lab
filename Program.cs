/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: Program.cs
* Purpose: Week 1 Rolodex demo. Displays welcome message, demonstrates
*          basic input/output, and shows inheritance + composition.
*/

using System;
using System.Collections.Generic;

namespace Rolodex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rolodex Contact Manager - Week 1";

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("      Rolodex Contact Manager – Week 1 Demonstration");
            Console.WriteLine("                    By: Morgan Moore");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("This Week 1 demo shows:");
            Console.WriteLine("- Inheritance (base + derived classes)");
            Console.WriteLine("- Composition (Address inside Contact)");
            Console.WriteLine("- Basic input/output");
            Console.WriteLine();

            Console.WriteLine("Press ENTER to display sample contacts...");
            Console.ReadLine();

            // Create sample contacts
            List<Contact> contacts = new List<Contact>();

            contacts.Add(new BusinessContact(
                "John", "Carter", "555-1001", "jcarter@corp.com",
                new Address("450 Corporate Dr", "Roanoke", "VA", "24019"),
                "Carter Industries"
            ));

            contacts.Add(new FamilyContact(
                "Morgan", "Moore", "540-555-9900", "mmoore@email.com",
                new Address("2518 Green Dr", "Draper", "VA", "24324"),
                "Cousin"
            ));

            contacts.Add(new FriendContact(
                "Rebecca", "Cowen", "540-222-5555", "rebecca@mail.com",
                new Address("105 Madison St", "Radford", "VA", "24141"),
                "Met at college"
            ));

            // Display the objects
            Console.WriteLine("\nDisplaying sample contacts:\n");

            foreach (Contact c in contacts)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(c.GetContactSummary()); // Polymorphic behavior
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\nEnd of Week 1 Demonstration.");
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
