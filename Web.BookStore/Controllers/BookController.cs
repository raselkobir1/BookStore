using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Models;
using Web.BookStore.Repository;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        //--------Webgentle running tutorials: 27
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var bookList = _bookRepository.GetAllBooks();
            return View(bookList);
        }

        public ViewResult GetBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return View(book);
        }

        public List<BookViewModel> SearchtBooks(string title, string authorName)
        {
            return _bookRepository.SearchBook(title,authorName);
        }
    }
}
