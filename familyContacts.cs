namespace MooreRolodexLab
{
    public class FamilyContact : Contact
    {
        public string Relationship { get; set; }

        public FamilyContact(int id, string first, string last, string phone,
            string email, Address address, string relationship)
            : base(id, first, last, phone, email, address)
        {
            Relationship = relationship;
        }

        public override string GetSummaryLine()
        {
            return $"{FirstName} {LastName} - {Relationship}";
        }
    }
}
