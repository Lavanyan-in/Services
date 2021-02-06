using Services.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitTest
{
    public class TestBooksContext : ILibraryManagementContext
    {
        public TestBooksContext()
        {
            this.Books = new TestBooksDbSet();
        }

        public DbSet<DBContext.Book> Books { get; set; }

        public void Dispose() { }
    }
}
