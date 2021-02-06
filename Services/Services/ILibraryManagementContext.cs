using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ILibraryManagementContext : IDisposable
    {
        DbSet<DBContext.Book> Books { get; }
    }
}
