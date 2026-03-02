using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Book
    {
        public class Book
        {
            public Guid Id { get; private set; }
            public int ISBN { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public int PagesAmount  { get; private set; }
            public string Genre { get; private set; }
            public Author Author { get; private set; }

        }

    }
}
