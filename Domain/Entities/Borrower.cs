using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Domain.ValueObjects;
using Domain.Common;

namespace Domain.Entities
{
    public class Borrower
    {
        public Guid Id { get; private set; }
        public FullName Name { get; private set; }
        public BorrowerAddress Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public List<Loan> Loans { get; private set; }
        public bool CanBorrow => Loans.Count < 5; // Max loan restriction
        public bool HasOverdueLoans => Loans.Exists(loan => loan.IsOverdue); // you can't borrow if you have overdue loans, homie.

        private Borrower() { } // For EF Core
        public Borrower(string firstName, string lastName, int zip, string city, string region, string streetName, string streetNumber, string phoneNumber, string email) 
        {
            Id = Guid.NewGuid();
            Name = new FullName(firstName, lastName); // Validation happens in BorrowerName
            Address = new BorrowerAddress(zip, city, region, streetName, streetNumber); // Validation happens in BorrowerAddress
            PhoneNumber = Guard.ValidateNotEmpty(phoneNumber, nameof(phoneNumber)); // No value object here, since ... well, maybe it'll show up later.
            Email = Guard.ValidateNotEmpty(email, nameof(email)); 
        }
    }
}