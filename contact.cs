/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: Contact.cs
* Purpose: Base class for all contact types.
* Demonstrates: Inheritance (base class), Composition (contains Address object)
*/

namespace Rolodex
{
    public class Contact
    {
        // COMPOSITION: Contact *has an* Address
        public Address Address { get; set; }

        // Base class properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string first, string last, string phone, string email, Address address)
        {
            FirstName = first;
            LastName = last;
            Phone = phone;
            Email = email;
            Address = address; // Composition demonstrated here
        }

        // Virtual method for polymorphism
        public virtual string GetContactSummary()
        {
            return $"{FirstName} {LastName}\nPhone: {Phone}\nEmail: {Email}\nAddress: {Address}";
        }
    }
}
