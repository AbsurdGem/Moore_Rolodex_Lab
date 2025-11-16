/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: FamilyContact.cs
* Purpose: Derived class for family members.
* Demonstrates: Inheritance
*/

namespace Rolodex
{
    public class FamilyContact : Contact
    {
        public string Relationship { get; set; }

        public FamilyContact(string first, string last, string phone, string email,
                             Address address, string relationship)
            : base(first, last, phone, email, address)
        {
            Relationship = relationship;
        }

        public override string GetContactSummary()
        {
            return $"[Family Contact]\n{base.GetContactSummary()}\nRelationship: {Relationship}";
        }
    }
}
