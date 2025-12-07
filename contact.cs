namespace MooreRolodexLab
{
    public abstract class Contact : IContactDisplay
    {
        public int Id { get; protected set; }   // ✅ FIXED (was blocking ContactManager)
        public string FirstName { get; protected set; } = "";
        public string LastName { get; protected set; } = "";
        public string PhoneNumber { get; protected set; } = "";
        public string Email { get; protected set; } = "";
        public Address Address { get; protected set; } = new Address("", "", "", "");

        protected Contact() { }

        protected Contact(int id, string first, string last, string phone, string email, Address address)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            Email = email;
            Address = address;
        }

        public virtual string GetSummaryLine()
        {
            return $"{Id}: {FirstName} {LastName} ({PhoneNumber})";
        }

        public virtual string GetDetailText()
        {
            return $"ID: {Id}\nName: {FirstName} {LastName}\nPhone: {PhoneNumber}\nEmail: {Email}\nAddress: {Address}";
        }
    }
}
