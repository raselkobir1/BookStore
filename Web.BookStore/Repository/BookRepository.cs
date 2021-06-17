using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookViewModel>> GetAllBooks()
        {
            List<BookViewModel> booksList = new List<BookViewModel>();
            var bookCollection = await _context.Books.ToListAsync(); 
            if(bookCollection.Count > 0)
            {
                foreach (var item in bookCollection)
                {
                    BookViewModel book = new BookViewModel()
                    {
                        Author = item.Author,
                        Category = item.Category,
                        Description = item.Description,
                        Title = item.Title,
                        LanguageId = item.LanguageId,
                        Language = item.Language.Name,
                        TotalPages = item.TotalPages,
                        Id = item.Id
                    };
                    booksList.Add(book);
                }
            }
            return booksList;
        }
        public async Task<BookViewModel> GetBookById(int id)
        {
            //var book = await _context.Books.FindAsync(id);
            var book = await _context.Books.Where(x => x.Id == id)
                .Select( book=> new BookViewModel() 
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();
            return book;
        }
        public List<BookViewModel> SearchBook(string title, string authorName)
        {
            //return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
            return null;
        }
        public async Task<int>AddNewBook(BookViewModel bookViewModel)
        {
            try
            {
                var book = new Books()
                {
                    Id = 0,
                    Author = bookViewModel.Author,
                    CretedOn = DateTime.UtcNow,
                    Description = bookViewModel.Description,
                    Title = bookViewModel.Title,
                    TotalPages = bookViewModel.TotalPages,
                    UpdatedOn = DateTime.UtcNow,
                    Category = bookViewModel.Category,
                    LanguageId = bookViewModel.LanguageId
                };
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return book.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //================ In-memory Data base=================
        //private List<BookViewModel> DataSource()
        //{
        //    return new List<BookViewModel>()
        //    {
        //        new BookViewModel(){Id=1, Title="Asp.Net Mvc core", Author="Rasel Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=2, Title="Angular", Author="Manik Islam", Category="Frontend Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=3, Title="React", Author="Jamal Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=4, Title="VueJs", Author="Kamal Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=5, Title="React Nativ", Author="Rasel Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=6, Title="Azure DevOps", Author="Kamal khan", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=7, Title="Asp.Net MVC", Author="Sajib islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=8, Title="SQL server 2018", Author="Reyad Mahbub", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=9, Title="Java Script", Author="Ariful islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=10, Title="Type Script", Author="Kawsarul Alam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=11, Title="Apps with Kotlin", Author="Azad Islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //        new BookViewModel(){Id=12, Title="Power Of Java", Author="Jalal Uddin", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
        //    };
        //}
    }
}
