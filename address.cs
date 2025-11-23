/* 
* Author: Morgan Moore
* Date:11/16/2025
* File: Address.cs
* Purpose: Represents the composition object inside Contact.
* Demonstrates: Composition (Contact has an Address)
*/

namespace MooreRolodexLab
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address(string street, string city, string state, string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {State} {Zip}";
        }
    }
}
