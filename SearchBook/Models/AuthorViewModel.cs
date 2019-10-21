using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchBook.Models
{
  
    public class AuthorViewModel
    {
        public List<Book> TopTenBooks { get; set; }

        public string AuthorName { get; set; }

        public double? AverageRate { get; set; }
    }
}