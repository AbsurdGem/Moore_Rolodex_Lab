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
    }
}
