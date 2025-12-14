/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: Contact.cs
 * Purpose:
 * Abstract base class for all contacts in the Rolodex application.
 * Demonstrates abstraction, inheritance, and shared properties
 * for derived contact types.
 */

namespace MooreRolodexLab
{
    public class Contact : IContactDisplay
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";

        public Contact() { }

        public Contact(int id, string first, string last, string phone, string email)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            Email = email;
        }

        public virtual string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} ({PhoneNumber})";
        }

        public virtual string GetDetailText()
        {
            return $"ID: {Id}\nName: {FirstName} {LastName}\nPhone: {PhoneNumber}\nEmail: {Email}";
        }
        public override string ToString()
        {
            return $"ID: {Id} | {FirstName} {LastName} | Phone: {PhoneNumber} | Email: {Email}";
        }

    }
}
