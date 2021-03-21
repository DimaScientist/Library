using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;

namespace Library.Services
{
    public static class BookService
    {

        public static string GetStringName(string name)
        {
            byte[] byteSentByClient = Encoding.UTF8.GetBytes(name);
            return Encoding.ASCII.GetString(byteSentByClient);
        }

        public static string GetAuthorNameById(int id)
        {
            string name = "";
            using (LibraryContext db = new LibraryContext())
            {
                Author book = db.Authors.Find(id);
                name = book.Name;
            }
            return name; ;
        }


        public static int GetAuthorIdByName(string name)
        {
            int id = 0;
            using(LibraryContext db = new LibraryContext())
            {
                var authors = db.Authors.Where(a => a.Name.ToLower() == name.ToLower());
                foreach (Author author in authors.ToList())
                    id = author.Id;
            }
            return id;
        }


        public static string GetGanreNameById(int id)
        {
            string name = "";
            using (LibraryContext db = new LibraryContext())
            {
                Genre genre = db.Genres.Find(id);
                name = genre.name;
            }
            return name;
        }

        public static int GetGanreIdByName(string name)
        {
            int id = 0;
            using (LibraryContext db = new LibraryContext())
            {
                var genres = db.Genres.Where(g => g.name.ToLower() == name.ToLower());
                foreach (Genre genre in genres.ToList())
                    id = genre.Id;
            }
            return id;
        }


        public static BookEntity GetBookEntity(Book book) 
        {
            BookEntity bookEntity = new BookEntity();

            bookEntity.Id = book.Id;

            bookEntity.Name = book.Name;

            bookEntity.Author = GetAuthorNameById(book.AuthorId);

            bookEntity.Genre = GetGanreNameById(book.GenreId);

            bookEntity.Year = book.Year;

            bookEntity.Description = book.Description;

            return bookEntity;
        }


        public static Book GetBook(BookEntity bookEntity) 
        {
            Book book = new Book();

            if (bookEntity.Id != 0)
            {
                book.Id = bookEntity.Id;
            }

            book.Name = bookEntity.Name;

            book.AuthorId = GetAuthorIdByName(bookEntity.Author);

            book.GenreId = GetGanreIdByName(bookEntity.Genre);

            book.Year = bookEntity.Year;

            book.Description = bookEntity.Description;

            return book;
        }


        public static Book GetBookById(int id)
        {
            Book book = new Book();

            using (LibraryContext db = new LibraryContext())
            {
                book = db.Books.FirstOrDefault(b => b.Id == id);
            }

            return book;
        }

        public static BookGridEntity GetGridEntity(Book book)
        {
            BookGridEntity bookGridEntity = new BookGridEntity();

            bookGridEntity.Id = book.Id;

            bookGridEntity.Name = book.Name;

            bookGridEntity.Author = GetAuthorNameById(book.AuthorId);

            bookGridEntity.Year = book.Year;

            return bookGridEntity;
        }
    }
}