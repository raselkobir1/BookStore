using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context) 
        {
            _context = context;
        }
        public async Task<List<LanguageViewModel>> GetLanguages()
        {
            return await _context.Languages.Select(x => new LanguageViewModel() 
            {
            Id=x.Id,
            Name=x.Name,
            Description=x.Description
            }).ToListAsync();
        }
    }
}
