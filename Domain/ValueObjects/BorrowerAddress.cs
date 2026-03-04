using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

// I wanted to try and create a ValueObject and get that good constructor-ception going. 

namespace Domain.ValueObjects
{
    public class BorrowerAddress
    {
        public int ZipCode { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }
        public BorrowerAddress(int zipCode, string city, string region, string streetName, string streetNumber)
        {
            ZipCode = Guard.ValidatePositive(zipCode, nameof(zipCode));
            City = Guard.ValidateNotEmpty(city, nameof(city));
            Region = Guard.ValidateNotEmpty(region, nameof(region));
            StreetName = Guard.ValidateNotEmpty(streetName, nameof(streetName));
            StreetNumber = Guard.ValidateNotEmpty(streetNumber, nameof(streetNumber));
        }   
        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {ZipCode} {City}, {Region}";
        }
    }
}
