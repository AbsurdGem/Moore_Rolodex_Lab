namespace MooreRolodexLab
{
    public class BusinessContact : Contact
    {
        public string CompanyName { get; set; } = "";
        public string JobTitle { get; set; } = "";

        public BusinessContact() { }

        public BusinessContact(int id, string firstName, string lastName,
            string phone, string email, string companyName, string jobTitle)
            : base(id, firstName, lastName, phone, email)
        {
            CompanyName = companyName;
            JobTitle = jobTitle;
        }

        public override string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} – {JobTitle} at {CompanyName}";
        }

        public override string GetDetailText()
        {
            return base.GetDetailText() +
                   $"\nCompany: {CompanyName}\nJob Title: {JobTitle}";
        }
    }
}
