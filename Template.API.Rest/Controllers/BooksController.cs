using Microsoft.AspNetCore.Mvc;
using Template.API.Core.Interfaces;
using Template.API.Core.Models;
using Template.API.Infrastructure.Data;

namespace Template.API.Rest.Controllers
{
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookProvider _bookProvider;
        private readonly ILogger<BooksController> _logger;
        public BooksController(IBookProvider bookProvider, ILogger<BooksController> logger)
        {
            _bookProvider = bookProvider;
            _logger = logger;
        }

        [HttpGet("Title")]
        public async Task<IActionResult> GetBooksByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }
            _logger.LogInformation("GetBooksByTitle");
            var books = await _bookProvider.GetBooksByTitle(title);
              return Ok(books);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllBooks()
        {
            _logger.LogInformation("GetAllBooks");
            var books = await _bookProvider.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("Author")]
        public async Task<IActionResult> GetBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException($"'{nameof(author)}' cannot be null or whitespace.", nameof(author));
            }
            _logger.LogInformation("GetBooksByAuthor");
            var books = await _bookProvider.GetBooksByAuthor(author);
            return Ok(books);
        }

        [HttpGet("Genre")]
        public async Task<IActionResult> GetBooksByGenre(Genre genre)
        {
            
            _logger.LogInformation("GetBooksByGenre");
            var books = await _bookProvider.GetBooksByGenre(genre);
            return Ok(books);
        }

    }
}
