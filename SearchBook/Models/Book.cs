using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchBook.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        public string title { get; set; }

        public string authors { get; set; }

        public double average_rating { get; set; }

        public string isbn { get; set; }

        public string isbn13 { get; set; }

        public string language_code { get; set; }

        public int? number_pages { get; set; }

        public int? ratings_count { get; set; }

        public int? text_reviews_count { get; set; }
    }
}