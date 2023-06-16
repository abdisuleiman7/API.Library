using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.API.Core.Models;

namespace Template.API.Core.Interfaces
{
    public interface IBookProvider
    {
        public Task<List<Book>> GetBooksByTitle(string author);
        public Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetBooksByAuthor(string author);
        Task<List<Book>> GetBooksByGenre(Genre genre);
    }
}
