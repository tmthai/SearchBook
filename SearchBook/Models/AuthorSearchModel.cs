using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchBook.Models
{
    public class AuthorSearchModel
    {
        public string authorNameSearch { get; set; }
        public List<string> authorsList { get; set; }
    }
}