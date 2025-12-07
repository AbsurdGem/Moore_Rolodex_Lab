namespace MooreRolodexLab
{
    public class BusinessContact : Contact
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }

        public BusinessContact(int id, string first, string last, string phone,
            string email, Address address, string company, string job)
            : base(id, first, last, phone, email, address)
        {
            CompanyName = company;
            JobTitle = job;
        }

        public override string GetSummaryLine()
        {
            return $"{FirstName} {LastName} - {JobTitle} @ {CompanyName}";
        }
    }
}
