using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Services.DBContext;
using Services.Services;

namespace Services.Controllers
{
    public class BooksController : ApiController
    {
        private Services.ILibraryManagementContext db = new LibraryManagementEntities();

        public BooksController() { }

        public BooksController(ILibraryManagementContext context) {
            db = context;
        }

        [HttpGet]
        [Route("api/books")]
        public IHttpActionResult GetAllBooks()
        {
            return Ok(db.Books.ToList());
        }

        [HttpGet]
        [Route("api/books/search")]
        public IHttpActionResult SearchBooks(string bookAuthorName)
        {
            if (!isValid(bookAuthorName))
                return BadRequest();

            return Ok(db.Books.Where(x => x.BookName.ToLower().Contains(bookAuthorName.ToLower()) || x.AuthorName.ToLower().Contains(bookAuthorName.ToLower())).ToList());
        }

        private bool isValid(string model) {
            return !string.IsNullOrEmpty(model);
        }
    }
}