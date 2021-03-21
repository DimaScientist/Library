using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        //Id книги
        public int Id { get; set; }

        //Id автора
        public int AuthorId { get; set; }

        //Id жанра
        public int GenreId { get; set; }

        //Название книги
        public string Name { get; set; }

        //Год
        public int Year { get; set; }

        //Описание
        public string Description { get; set; }
    }
}