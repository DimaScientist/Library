using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Library.Models
{
    public class LibraryDbInitializer : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            db.Authors.Add(new Author { Id = 1, Name = "Пушкин"});
            db.Authors.Add(new Author { Id = 2, Name = "Толстой"});
            db.Authors.Add(new Author { Id = 3, Name = "Чехов" });
            db.Authors.Add(new Author { Id = 4, Name = "Булгаков" });
            db.Authors.Add(new Author { Id = 5, Name = "Достоевский"});
            db.Authors.Add(new Author { Id = 6, Name = "Шолохов" });

            db.Genres.Add(new Genre { Id = 1, name = "Роман"});
            db.Genres.Add(new Genre { Id = 2, name = "Рассказ" });
            db.Genres.Add(new Genre { Id = 3, name = "Повесть" });
            db.Genres.Add(new Genre { Id = 4, name = "Поэма" });

            db.Books.Add(new Book { 
                Id = 1, 
                AuthorId = 1, 
                GenreId = 1, 
                Name = "Капитанская дочка", 
                Year = 1836, 
                Description = "Повествует о восстании Пугачева", 
            });
            db.Books.Add(new Book
            {
                Id = 2,
                AuthorId = 1,
                GenreId = 4,
                Name = "Медный всадник",
                Year = 1833,
                Description = "Поэма о памятнике Петру I",
            });
            db.Books.Add(new Book
            {
                Id = 3,
                AuthorId = 2,
                GenreId = 1,
                Name = "Война и мир",
                Year = 1836,
                Description = "Роман-эпопея, повествующая \nоб Отечественной войне 1812 года",
            });
            db.Books.Add(new Book
            {
                Id = 4,
                AuthorId = 3,
                GenreId = 2,
                Name = "Хамелеон",
                Year = 1884,
                Description = "Рассказывет про случай на базаре"
            });
            db.Books.Add(new Book
            {
                Id = 5,
                AuthorId = 3,
                GenreId = 2,
                Name = "Каштанка",
                Year = 1887,
                Description = "Рассказывает о собаке"
            });
            db.Books.Add(new Book
            {
                Id = 6,
                AuthorId = 4,
                GenreId = 1,
                Name = "Белая гвардия",
                Year = 1923,
                Description = "Описывает гражданскую \nвойну в России"
            });
            db.Books.Add(new Book
            {
                Id = 7,
                AuthorId = 3,
                GenreId = 3,
                Name = "Дуэль",
                Year = 1891,
                Description = "Действия происходят на Кавказе"
            });
            db.Books.Add(new Book
            {
                Id = 8,
                AuthorId = 5,
                GenreId = 1,
                Name = "Бесы",
                Year = 1872,
                Description = "В романе отражена нечаевщина"
            });
            db.Books.Add(new Book
            {
                Id = 9,
                AuthorId = 6,
                GenreId = 2,
                Name = "Судьба человека",
                Year = 1956,
                Description = "Рассказывает о судьбе \nчеловека в ВОВ"
            });
            base.Seed(db);
        }
    }
}