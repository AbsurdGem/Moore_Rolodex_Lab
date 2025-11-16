/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: FriendContact.cs
* Purpose: Derived class for friend contacts.
* Demonstrates: Inheritance
*/

namespace Rolodex
{
    public class FriendContact : Contact
    {
        public string HowWeMet { get; set; }

        public FriendContact(string first, string last, string phone, string email,
                             Address address, string howWeMet)
            : base(first, last, phone, email, address)
        {
            HowWeMet = howWeMet;
        }

        public override string GetContactSummary()
        {
            return $"[Friend Contact]\n{base.GetContactSummary()}\nHow We Met: {HowWeMet}";
        }
    }
}
