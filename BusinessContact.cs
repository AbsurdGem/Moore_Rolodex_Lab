/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: BusinessContact.cs
 * Purpose: Represents business contacts. Inherits from abstract Contact.
 */

namespace MooreRolodexLab
{
    public class BusinessContact : Contact
    {
        public string CompanyName { get; private set; } = "";
        public string JobTitle { get; private set; } = "";

        public BusinessContact() { }

        public BusinessContact(int id, string firstName, string lastName,
            string phone, string email, Address address,
            string companyName, string jobTitle)
            : base(id, firstName, lastName, phone, email, address)
        {
            CompanyName = companyName;
            JobTitle = jobTitle;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} – {JobTitle} at {CompanyName}";
        }

        public override string GetDetailText()
        {
            return base.GetDetailText() +
                   $"\nCompany: {CompanyName}\nJob Title: {JobTitle}";
        }
    }
}
