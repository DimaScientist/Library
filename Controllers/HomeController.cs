using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index(string author, int? year, string genre)
        {
            using (LibraryContext db = new LibraryContext())
            {
                IQueryable<Book> books = db.Books;
                List<BookGridEntity> bookGridEntities = new List<BookGridEntity>();

                if (!String.IsNullOrEmpty(author))
                {
                    int id = BookService.GetAuthorIdByName(author);
                    books = books.Where(b => b.AuthorId == id);
                }

                if (year != null && year != 0)
                {
                    books = books.Where(b => b.Year == year);
                }

                if (!String.IsNullOrEmpty(genre))
                {
                    int id = BookService.GetGanreIdByName(genre);
                    books = books.Where(b => b.GenreId == id);
                }

                foreach (Book book in books.ToList())
                {
                    bookGridEntities.Add(BookService.GetGridEntity(book));
                }

                BooksListViewModel booksListView = new BooksListViewModel
                {
                    BookGridEntities = bookGridEntities,
                    Author = author,
                    Year = year,
                    Ganre = genre,

                };

                return View(booksListView);
            }
        }

        public ActionResult NewBook()
        {
            BookEntity bookEntity = new BookEntity();

            return PartialView(bookEntity);
        }

        [HttpPost]
        public ActionResult NewBook(BookEntity bookEntity)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Book book = new Book();
                int authorId = BookService.GetAuthorIdByName(bookEntity.Author);
                int genreId = BookService.GetGanreIdByName(bookEntity.Genre);

                if (authorId == 0)
                {
                    Author newAuthor = new Author();
                    newAuthor.Name = bookEntity.Author;
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                }

                if (genreId == 0)
                {
                    Genre newGenre = new Genre();
                    newGenre.name = bookEntity.Genre;
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                }
                
                book = BookService.GetBook(bookEntity);
                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;

            using (LibraryContext db = new LibraryContext())
            {

                bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;
                db.Configuration.ValidateOnSaveEnabled = false;

                var book = db.Books.FirstOrDefault(b => b.Id == id);

                if(book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    result = true;
                    db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                }

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditBook(int id)
        {
            Book book = BookService.GetBookById(id);

            if(book == null)
            {
                return HttpNotFound();
            }

            return PartialView(BookService.GetBookEntity(book));
        }

        [HttpPost]
        public ActionResult EditBook(BookEntity bookEntity)
        {
            Book book = BookService.GetBook(bookEntity);

            using(LibraryContext db = new LibraryContext())
            {
                db.Books.Remove((Book)db.Books.Find(book.Id));
                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}