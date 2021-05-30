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
                new BookViewModel(){Id=1, Title="Asp.Net Mvc core", Author="Rasel Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=2, Title="Angular", Author="Manik Islam", Category="Frontend Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=3, Title="React", Author="Jamal Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=4, Title="VueJs", Author="Kamal Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=5, Title="React Nativ", Author="Rasel Kabir", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=6, Title="Azure DevOps", Author="Kamal khan", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=7, Title="Asp.Net MVC", Author="Sajib islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=8, Title="SQL server 2018", Author="Reyad Mahbub", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=9, Title="Java Script", Author="Ariful islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=10, Title="Type Script", Author="Kawsarul Alam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=11, Title="Apps with Kotlin", Author="Azad Islam", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
                new BookViewModel(){Id=12, Title="Power Of Java", Author="Jalal Uddin", Category="Backent Programing", Language="English", TotalPages=220, Description="This is Discription part"},
            };
        }
    }
}
