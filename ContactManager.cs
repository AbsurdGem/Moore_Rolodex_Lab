using System.Collections.Generic;
using System.Linq;

namespace MooreRolodexLab
{
    public class ContactManager
    {
        private readonly List<IContactDisplay> _contacts = new();
        private int _nextId = 1;

        public void SeedSampleData()
        {
            AddContact(new BusinessContact(0, "Alex", "Green", "555-1111", "alex@company.com", "Tech Corp", "Manager"));
            AddContact(new FamilyContact(0, "Stephen", "Underwood", "555-4444", "steve@email.com", "Boyfriend"));
            AddContact(new FamilyContact(0, "Rebecca", "Moore", "555-2222", "becca@example.com", "Sister"));
            AddContact(new FriendContact(0, "Jordan", "Lee", "555-3333", "jlee@mail.com", "Jordy"));
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _nextId++;
            _contacts.Add(contact);
        }

        public List<IContactDisplay> GetAllContacts()
        {
            return _contacts.ToList();
        }

        public List<IContactDisplay> GetContactsByLastInitial(char initial)
        {
            initial = char.ToUpper(initial);

            return _contacts.Where(c =>
            {
                if (c is Contact cc &&
                    cc.LastName.Length > 0 &&
                    char.ToUpper(cc.LastName[0]) == initial)
                {
                    return true;
                }
                return false;
            }).ToList();
        }
    }
}
