using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchBook.Models
{
    /*
     * Database context represent the book table, which contains the books business has 
     */
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}