using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.API.Core.Interfaces;
using Template.API.Core.Models;
using Template.API.Infrastructure.Data;

namespace Template.API.Infrastructure.Providers
{
    public class BookProvider:IBookProvider
    {
        private readonly ILogger<IBookProvider> _logger;

        private readonly LibraryContext _context;
        public int MyProperty { get; set; }


        public BookProvider(ILogger<IBookProvider> logger, LibraryContext context)
        {

            _logger = logger;
            _context = context;
        }


        public async Task<List<Book>> GetBooksByTitle(string title)
        {

            _logger.LogInformation("GetBooksByTitle");
            List<Book> books;
            try
            {
                 books = await _context.Books.Where(x => x.Title.ToLower().StartsWith(title.ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Cant get the books. Ex:{ex}");
            }

            return books;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}