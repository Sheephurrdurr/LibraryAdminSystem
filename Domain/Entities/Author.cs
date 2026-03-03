using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Author
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public ICollection<Book> Books { get; private set; } = new List<Book>();

    }
}
