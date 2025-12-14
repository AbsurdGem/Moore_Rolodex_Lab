/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: BusinessContact.cs
 * Purpose:
 * Represents a business contact in the Rolodex.
 * Demonstrates inheritance by extending Contact and adds
 * business-specific properties such as company name and job title.
 */

namespace MooreRolodexLab
{
    public class BusinessContact : Contact
    {
        public string CompanyName { get; set; } = "";
        public string JobTitle { get; set; } = "";

        public BusinessContact() { }

        public BusinessContact(int id, string firstName, string lastName,
            string phone, string email, string companyName, string jobTitle)
            : base(id, firstName, lastName, phone, email)
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
        public override string ToString()
        {
            return base.ToString() + $" | Company: {CompanyName} | Job: {JobTitle}";
        }

    }
}
