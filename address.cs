/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: Address.cs
 * Purpose: Represents the composition object inside Contact.
 * Demonstrates: Composition (Contact HAS an Address)
 */

namespace MooreRolodexLab
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }

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
