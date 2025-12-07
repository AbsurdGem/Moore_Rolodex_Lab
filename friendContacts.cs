namespace MooreRolodexLab
{
    public class FriendContact : Contact
    {
        public string Nickname { get; set; }

        public FriendContact(int id, string first, string last, string phone,
            string email, Address address, string nickname)
            : base(id, first, last, phone, email, address)
        {
            Nickname = nickname;
        }

        public override string GetSummaryLine()
        {
            return $"{FirstName} {LastName} (\"{Nickname}\")";
        }
    }
}
