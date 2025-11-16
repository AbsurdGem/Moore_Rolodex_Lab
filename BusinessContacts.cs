/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: BusinessContact.cs
* Purpose: Derived class representing a business contact.
* Demonstrates: Inheritance (child of Contact)
*/

namespace Rolodex
{
    public class BusinessContact : Contact
    {
        public string CompanyName { get; set; }

        public BusinessContact(string first, string last, string phone, string email,
                               Address address, string company)
            : base(first, last, phone, email, address)   // INHERITANCE HERE
        {
            CompanyName = company;
        }

        public override string GetContactSummary()
        {
            return $"[Business Contact]\n{base.GetContactSummary()}\nCompany: {CompanyName}";
        }
    }
}
