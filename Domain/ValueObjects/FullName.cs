using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.ValueObjects
{
    public class FullName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public FullName(string firstName, string lastName)
        {
            FirstName = Guard.ValidateNotEmpty(firstName, nameof(firstName));
            LastName = Guard.ValidateNotEmpty(lastName, nameof(lastName));
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

// Right, that's enough needless complexity for now. 
