using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchBook;
using SearchBook.Controllers;
using SearchBook.Models;

namespace SearchBook.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController controller = new HomeController();

        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchForAuthorTest()
        {
            /*TEST 1: Non-existing Value: example: abc */
            ViewResult result = controller.SearchForAuthor("abc") as ViewResult;

            var model = (AuthorSearchModel)result.ViewData.Model;

            Assert.AreEqual("abc", model.authorNameSearch);
            Assert.AreEqual(0, model.authorsList.Count);
        }

        [TestMethod]
        public void SearchForAuthorTest_Null()
        {

            /*TEST 2: Null Value */
            ViewResult resultNull = controller.SearchForAuthor("NULL") as ViewResult;

            var modelNull = (AuthorSearchModel)resultNull.ViewData.Model;

            Assert.AreEqual("NULL", modelNull.authorNameSearch);
            Assert.AreEqual(0, modelNull.authorsList.Count);

        }

        [TestMethod]
        public void Contact()
        {
          
            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
