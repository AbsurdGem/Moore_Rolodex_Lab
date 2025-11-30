/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: ContactManager.cs
 * Purpose: Handles composition of Contact objects, demonstrates object creation.
 */

namespace MooreRolodexLab
{
    public class ContactManager
    {
        private List<Contact> _contacts = new List<Contact>();
        private int _nextId = 1;  // ensures unique IDs

        public void AddContact(Contact c)
        {
            c.GetType().GetProperty("Id")?.SetValue(c, _nextId++);
            _contacts.Add(c);
        }

        public List<Contact> GetAllContacts() => _contacts;

        public List<Contact> GetByLastInitial(char letter)
        {
            return _contacts
                .Where(c => c.LastName.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
