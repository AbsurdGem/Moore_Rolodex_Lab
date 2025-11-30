using MooreRolodexLab;

Console.WriteLine("============================================");
Console.WriteLine("   Week 3 – Abstraction, Constructors, OOP");
Console.WriteLine("   Rolodex Project – Morgan Moore");
Console.WriteLine("============================================");
Console.WriteLine("Welcome! This week demonstrates abstraction, constructors, and access specifiers.\n");

var manager = new ContactManager();

// Example test data
manager.AddContact(new BusinessContact(
    0, "Alex", "Green", "555-1111", "alex@company.com",
    new Address("101 Main St", "Radford", "VA", "24141"),
    "Tech Corp", "Manager"));

foreach (var contact in manager.GetAllContacts())
{
    Console.WriteLine(contact.GetSummaryLine());
}
