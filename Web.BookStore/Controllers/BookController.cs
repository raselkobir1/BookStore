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
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public List<BookViewModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookViewModel GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<BookViewModel> SearchtBooks(string title, string authorName)
        {
            return _bookRepository.SearchBook(title,authorName);
        }
    }
}
