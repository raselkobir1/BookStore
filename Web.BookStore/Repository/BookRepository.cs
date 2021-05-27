using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Models;

namespace Web.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookViewModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookViewModel GetBookById(int id)
        {
            return DataSource().Where(x=> x.Id == id).FirstOrDefault();
        }
        public List<BookViewModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }
        private List<BookViewModel> DataSource() 
        {
            return new List<BookViewModel>()
            {
                new BookViewModel(){Id=1, Title="Asp.Net Mvc core", Author="Rasel Kabir"},
                new BookViewModel(){Id=2, Title="Angular", Author="Manik Islam"},
                new BookViewModel(){Id=3, Title="React", Author="Jamal Kabir"},
                new BookViewModel(){Id=4, Title="VueJs", Author="Kamal Kabir"},
                new BookViewModel(){Id=5, Title="Mathmatics", Author="Rasel Kabir"},
            };
        }
    }
}
