using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchBook.Models;
using System.Web.WebPages;

namespace SearchBook.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Display books list for index page.
         */
        public ActionResult Index()
        {
            BookContext b = new BookContext();

            var books = b.Books.ToList();
            
            return View(books);
        }

        /*
         * Display a book detail.
         * Have to make sure if the exist a bookId or not, to prevent error page for the book.
         */
        public ActionResult ABook(int? bookId)
        {
            if (bookId == null || bookId == 0)
            {
                return RedirectToAction("Index");
            }

            BookContext b = new BookContext();

            Book aBook = b.Books.Single(ab => ab.Id == bookId);

            return View(aBook);
        }
        
       
        /*
         * This controls searching for an author feature.
         * It will return a list of authors.
         */
        public ActionResult SearchForAuthor(string txtNameSearch)
        {
          
            BookContext b = new BookContext();

            var authorSearch = new AuthorSearchModel();
            authorSearch.authorNameSearch = txtNameSearch;

            authorSearch.authorsList = (from book in b.Books
                                        where book.authors.Contains(txtNameSearch)
                                        select book.authors).Distinct().ToList();

            return View(authorSearch);
        }

        /*
         * This displays an author details. It will show top ten books related to that
         * author with the high rating on the top.
         * Check if no author name, show Search author page.
         * Check the number of ratings, then decide to calculate the Average rating or not.
         */
        public ActionResult AboutAuthor(String authorName)
        {
            BookContext b = new BookContext();
            var authorViewModel = new AuthorViewModel();

            if (authorName == null)
                return RedirectToAction("SearchForAuthor");

            authorViewModel.TopTenBooks = (from book in b.Books
                                            where book.authors.Equals(authorName)
                                            orderby book.average_rating descending
                                            select book).Take(10).ToList();
            
            var ratings = (from book in b.Books
                where book.authors.Equals(authorName)
                select book.average_rating).ToList();

            if(ratings.Count == 0)
            {
                authorViewModel.AverageRate = null;
            } else
            {
                authorViewModel.AverageRate = ratings.Average();
            }
            
            authorViewModel.AuthorName = authorName;       

            return View(authorViewModel);
        }

        /*
         * Display the contact information of the business.
         */
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}