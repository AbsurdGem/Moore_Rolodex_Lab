/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: FamilyContact.cs
 * Purpose: Represents a family contact.
 */

namespace MooreRolodexLab
{
    public class FamilyContact : Contact
    {
        public string Relationship { get; private set; } = "";

        public FamilyContact() { }

        public FamilyContact(int id, string firstName, string lastName,
            string phone, string email, string relationship, Address address)
            : base(id, firstName, lastName, phone, email, address)
        {
            Relationship = relationship;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} ({Relationship})";
        }

        public override string GetDetailText()
        {
            return $"Family Contact\n-----------------" +
                   $"\nName: {FirstName} {LastName}" +
                   $"\nRelationship: {Relationship}" +
                   $"\nPhone: {PhoneNumber}" +
                   $"\nEmail: {Email}" +
                   $"\nAddress: {Address}";
        }
    }
}
