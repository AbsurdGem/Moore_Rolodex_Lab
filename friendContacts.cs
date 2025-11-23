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
    }
}
