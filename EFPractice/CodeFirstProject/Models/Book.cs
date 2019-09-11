using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Models
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public Author Author { get; set; }
    }
}
