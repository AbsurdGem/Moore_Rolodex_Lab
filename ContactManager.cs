using System.Collections.Generic;

namespace MooreRolodexLab
{
    public class ContactManager
    {
        private readonly List<Contact> _contacts = new();
        private int _nextId = 1;

        public void AddContact(Contact contact)
        {
            contact.GetType()
                   .GetProperty("Id")!
                   .SetValue(contact, _nextId++);   // ✅ Safe auto-ID assignment

            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts() => _contacts;
    }
}
