using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Decription { get; set; }
        public int Pages { get; set; }
        public String[] Codes { get; set; }
        public HashSet<Author> Authors { get; set; }
        public DateTime Published { get; set; }
        public Publisher Publisher { get; set; }
    }

    public class Author
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthday { get; set; }
        public HashSet<Book> Books { get; set; }
    }

    public class Publisher
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Country Country { get; set; }
        public HashSet<Book> Books { get; set; }
    }

    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}
