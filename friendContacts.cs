/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: FriendContact.cs
 * Purpose:
 * Represents a friend contact in the Rolodex.
 * Demonstrates inheritance by extending Contact and adds
 * friend-specific information such as nickname.
 */

namespace MooreRolodexLab
{
    public class FriendContact : Contact
    {
        public string Nickname { get; set; } = "";

        public FriendContact() { }

        public FriendContact(int id, string firstName, string lastName,
            string phone, string email, string nickname)
            : base(id, firstName, lastName, phone, email)
        {
            Nickname = nickname;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} \"{Nickname}\" {LastName}";
        }

        public override string GetDetailText()
        {
            return base.GetDetailText() +
                   $"\nNickname: {Nickname}";
        }
        public override string ToString()
        {
            return base.ToString() + $" | Nickname: {Nickname}";
        }

    }
}
