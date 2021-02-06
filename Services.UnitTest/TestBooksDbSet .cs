using Services.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitTest
{
    class TestBooksDbSet : TestDbSet<Book>
    {
        public override Book Find(params object[] keyValues)
        {
            return this.SingleOrDefault(book => book.BookId == (int)keyValues.Single());
        }
    }
}
