/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: FamilyContact.cs
 * Purpose:
 * Represents a family contact in the Rolodex.
 * Demonstrates inheritance by extending Contact and adds
 * family-specific information such as relationship.
 */

namespace MooreRolodexLab
{
    public class FamilyContact : Contact
    {
        public string Relationship { get; set; } = "";

        public FamilyContact() { }

        public FamilyContact(int id, string firstName, string lastName,
            string phone, string email, string relationship)
            : base(id, firstName, lastName, phone, email)
        {
            Relationship = relationship;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} ({Relationship})";
        }

        public override string GetDetailText()
        {
            return base.GetDetailText() +
                   $"\nRelationship: {Relationship}";
        }
        public override string ToString()
        {
            return base.ToString() + $" | Relationship: {Relationship}";
        }

    }
}
