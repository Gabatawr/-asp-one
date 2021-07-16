using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc.Data
{
    public class Book
    {
        public Guid Id { get; set; }

        [Display(Name = "Cover")]
        [DataType(DataType.Url)]
        public Uri CoverImageUri { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Book title", ShortName = "Title", Order = 0)]
        public String Title { get; set; }

        [Display(Name = "Book decription", ShortName = "Decription", Order = 1)]
        public String Decription { get; set; }

        public int Pages { get; set; }
        public HashSet<string> Codes { get; set; }
        public HashSet<Author> Authors { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:Y}")]
        public DateTime Published { get; set; }

        public Publisher Publisher { get; set; }
    }

    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [MinLength(2)]
        [Display(Name = "Last name")]
        public String LastName { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:Y}")]
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
