/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: Contact.cs
 * Purpose: Abstract base class for all contact types. 
 * Demonstrates abstraction, constructors, access specifiers, and interface usage.
 */

namespace MooreRolodexLab
{
    public abstract class Contact : IContactDisplay
    {
        // Access specifiers updated: ID cannot be publicly changed.
        public int Id { get; protected set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";

        // Composition: Contact HAS an Address.
        public Address Address { get; set; }

        // Empty constructor
        protected Contact() { }

        // Main constructor used by all derived classes
        protected Contact(int id, string first, string last, string phone, string email, Address address)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            Email = email;
            Address = address;
        }

        // REQUIRED by interface – marked abstract for polymorphism
        public abstract string GetSummaryLine();

        // Virtual method used by derived classes to extend details
        public virtual string GetDetailText()
        {
            return
                $"ID: {Id}\n" +
                $"Name: {FirstName} {LastName}\n" +
                $"Phone: {PhoneNumber}\n" +
                $"Email: {Email}\n" +
                $"Address: {Address}";
        }
    }
}
