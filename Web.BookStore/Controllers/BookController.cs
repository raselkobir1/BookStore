using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Data;
using Web.BookStore.Models;
using Web.BookStore.Repository;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        //--------Webgentle running tutorials: 58
        private readonly BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository; 
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var bookList = await _bookRepository.GetAllBooks();
            return View(bookList);
        }

        [Route("book-details/{id}", Name = "bookDetails")]
        public async Task<ViewResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            return View(book);
        }

        public List<BookViewModel> SearchtBooks(string title, string authorName)
        {
            return _bookRepository.SearchBook(title,authorName);
        }
        //AddNewBook
        public async Task<ActionResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess; 
            ViewBag.BookId = bookId;
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
            #region dropDown hard code
            //ViewBag.Language = new List<string> { "Bangladesh", "India", "English", "Urdu" };   //Dropdown way-1 
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");  //way-2 
            //ViewBag.Language = GetLanguage().Select(x=> new SelectListItem()  //way-3 best practice
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();
            #endregion
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookViewModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
               
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            //ViewBag.Language = new List<string> { "Bangladesh", "India", "English", "Urdu" };
            return View();
        }
        //private List<LanguageViewModel> GetLanguage()
        //{
        //    return new List<LanguageViewModel>()
        //    {
        //        new LanguageViewModel(){Id=1, Text="Bangla"},
        //        new LanguageViewModel(){Id=2, Text="English"},
        //        new LanguageViewModel(){Id=3, Text="Hindi"},
        //        new LanguageViewModel(){Id=4, Text="Arabic"}
        //    };
        //}
    }
}
