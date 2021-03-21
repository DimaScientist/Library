using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<BookGridEntity> BookGridEntities { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public string Ganre { get; set; }
    }
}