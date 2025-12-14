/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: Program.cs
 * Purpose:
 * Console-based UI for Rolodex contact management.
 * Allows users to Create, Read, Update, and Delete contacts
 * stored in an SQLite database.
 */

using System;
using System.Collections.Generic;

namespace MooreRolodexLab
{
    class Program
    {
        static DatabaseHelper db = new DatabaseHelper();

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine(" Morgan Moore - Week 4 Database Interactions ");
            Console.WriteLine(" Rolodex Contact Manager ");
            Console.WriteLine("==============================================\n");

            Console.WriteLine("Welcome! This program allows you to manage contacts using SQLite.\n");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View All Contacts");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ViewAllContacts();
                        break;
                    case "3":
                        UpdateContact();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ✅ ADD CONTACT
        static void AddContact()
        {
            Console.WriteLine("\nContact Type:");
            Console.WriteLine("1. Business");
            Console.WriteLine("2. Family");
            Console.WriteLine("3. Friend");
            Console.Write("Select: ");
            string type = Console.ReadLine() ?? "";

            Console.Write("First Name: ");
            string first = Console.ReadLine() ?? "";

            Console.Write("Last Name: ");
            string last = Console.ReadLine() ?? "";

            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Contact contact;

            if (type == "1")
            {
                Console.Write("Company: ");
                string company = Console.ReadLine() ?? "";

                Console.Write("Job Title: ");
                string job = Console.ReadLine() ?? "";

                contact = new BusinessContact(0, first, last, phone, email, company, job);
            }
            else if (type == "2")
            {
                Console.Write("Relationship: ");
                string relationship = Console.ReadLine() ?? "";

                contact = new FamilyContact(0, first, last, phone, email, relationship);
            }
            else if (type == "3")
            {
                Console.Write("Nickname: ");
                string nickname = Console.ReadLine() ?? "";

                contact = new FriendContact(0, first, last, phone, email, nickname);
            }
            else
            {
                Console.WriteLine("Invalid contact type.");
                return;
            }

            db.InsertContact(contact);
            Console.WriteLine("✅ Contact added successfully.");
        }

        // ✅ VIEW ALL CONTACTS
        static void ViewAllContacts()
        {
            List<Contact> contacts = db.GetAllContacts();

            Console.WriteLine("\n--- CONTACT LIST ---");

            foreach (var c in contacts)
            {
                Console.WriteLine(c);
            }
        }

        // ✅ UPDATE CONTACT
        static void UpdateContact()
        {
            Console.Write("Enter Contact ID to Update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("New First Name: ");
            string first = Console.ReadLine() ?? "";

            Console.Write("New Last Name: ");
            string last = Console.ReadLine() ?? "";

            Console.Write("New Phone: ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("New Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Type (Business/Family/Friend): ");
            string type = Console.ReadLine() ?? "";

            Contact updated;

            if (type == "Business")
            {
                Console.Write("Company: ");
                string company = Console.ReadLine() ?? "";

                Console.Write("Job Title: ");
                string job = Console.ReadLine() ?? "";

                updated = new BusinessContact(id, first, last, phone, email, company, job);
            }
            else if (type == "Family")
            {
                Console.Write("Relationship: ");
                string relationship = Console.ReadLine() ?? "";

                updated = new FamilyContact(id, first, last, phone, email, relationship);
            }
            else
            {
                Console.Write("Nickname: ");
                string nickname = Console.ReadLine() ?? "";

                updated = new FriendContact(id, first, last, phone, email, nickname);
            }

            db.UpdateContact(updated);
            Console.WriteLine("✅ Contact updated.");
        }

        // ✅ DELETE CONTACT
        static void DeleteContact()
        {
            Console.Write("Enter Contact ID to Delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            db.DeleteContact(id);
            Console.WriteLine("✅ Contact deleted.");
        }
    }
}
