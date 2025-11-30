/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: FriendContact.cs
 * Purpose: Represents a friend contact.
 */

namespace MooreRolodexLab
{
    public class FriendContact : Contact
    {
        public string Nickname { get; private set; } = "";

        public FriendContact() { }

        public FriendContact(int id, string firstName, string lastName,
            string phone, string email, string nickname, Address address)
            : base(id, firstName, lastName, phone, email, address)
        {
            Nickname = nickname;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} \"{Nickname}\" {LastName}";
        }

        public override string GetDetailText()
        {
            return $"Friend Contact\n-----------------" +
                   $"\nName: {FirstName} {LastName}" +
                   $"\nNickname: {Nickname}" +
                   $"\nPhone: {PhoneNumber}" +
                   $"\nEmail: {Email}" +
                   $"\nAddress: {Address}";
        }
    }
}
