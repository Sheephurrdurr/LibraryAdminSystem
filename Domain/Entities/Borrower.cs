using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Borrower
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<Loan> Loans { get; private set; }
    }
}
