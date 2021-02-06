using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using Services.Controllers;
using Services.DBContext;
using System.Collections.Generic;

namespace Services.UnitTest
{
    [TestClass]
    public class TestBooksController
    {
        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var controller = new BooksController(GetContext());
            var result = (OkNegotiatedContentResult<List<Book>>)controller.GetAllBooks();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Content.Count);
        }

        [TestMethod]
        public void SearchBooks_SerachParameterIsBookName_ReturnBooks()
        {
            var controller = new BooksController(GetContext());
            var result = (OkNegotiatedContentResult<List<Book>>)controller.SearchBooks("Beginning ASP.NET 4.5.1");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content[0].BookId);
        }

        [TestMethod]
        public void SearchBooks_SerachParameterIsAuthorName_ReturnBooks()
        {
            var controller = new BooksController(GetContext());
            var result = (OkNegotiatedContentResult<List<Book>>)controller.SearchBooks("Imar Spaanjaars");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content[0].BookId);
        }

        [TestMethod]
        public void SearchBooks_SerachParameterIsPartialBookName_ReturnBooks()
        {
            var controller = new BooksController(GetContext());
            var result = (OkNegotiatedContentResult<List<Book>>)controller.SearchBooks("Professional");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Count);
            Assert.AreEqual(10, result.Content[2].BookId);
            Assert.AreEqual("Professional AngularJs 1.8.1", result.Content[2].BookName);
        }

        [TestMethod]
        public void SearchBooks_SerachParameterIsPartialAuthorName_ReturnBooks()
        {
            var controller = new BooksController(GetContext());
            var result = (OkNegotiatedContentResult<List<Book>>)controller.SearchBooks("Millet");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count);
            Assert.AreEqual(1, result.Content[0].BookId);
            Assert.AreEqual("Professional ASP.Net Design Patterns", result.Content[0].BookName);
            Assert.AreEqual("Scott Millet", result.Content[0].AuthorName);
        }

        [TestMethod]
        public void SearchBooks_EmptyStringPassedAsParameter_ShouldReturnBadRequest()
        {
            var controller = new BooksController(new TestBooksContext());
            var result = controller.SearchBooks("");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        private TestBooksContext GetContext() {
            var context = new TestBooksContext();
            context.Books.Add(new Book { BookId = 1, BookName = "Professional ASP.Net Design Patterns", AuthorName = "Scott Millet", BookStatus = "Available", CreatedBy = "lavanya" });
            context.Books.Add(new Book { BookId = 2, BookName = "Programming ASP.NET", AuthorName = "Jesse Liberty", BookStatus = "Rented", CreatedBy = "lavanya" });
            context.Books.Add(new Book { BookId = 3, BookName = "Beginning ASP.NET 4.5.1", AuthorName = "Imar Spaanjaars", BookStatus = "Available", CreatedBy = "lavanya" });
            context.Books.Add(new Book { BookId = 9, BookName = "Professional ASP.NET 3.5 AJAX", AuthorName = "Bill Evjen, Matt Gibs", BookStatus = "Available", CreatedBy = "lavanya" });
            context.Books.Add(new Book { BookId = 10, BookName = "Professional AngularJs 1.8.1", AuthorName = "Joseph D", BookStatus = "Available", CreatedBy = "lavanya" });

            return context;
        }
    }
}
