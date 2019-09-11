using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstProject.Models;

namespace CodeFirstProject.DAL
{
    class AppContext : DbContext
    {
        public AppContext() : base("LibraryDbConnection")
        {
        }


        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
