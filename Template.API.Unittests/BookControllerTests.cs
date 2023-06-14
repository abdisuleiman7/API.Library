using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Template.API.Core.Interfaces;
using Template.API.Core.Models;
using Template.API.Infrastructure.Data;
using Template.API.Infrastructure.Providers;
using Template.API.Rest.Controllers;
using static System.Reflection.Metadata.BlobBuilder;

namespace Template.API.Unittests
{
    public class BookControllerTests
    {
        private BooksController _sut;
        private Mock<IBookProvider> _bookProviderMock;
        private Mock<ILogger<BooksController>> _bookProviderLoggerMock;
        public BookControllerTests()
        {
            _bookProviderMock = new Mock<IBookProvider>();
            _bookProviderLoggerMock = new Mock<ILogger<BooksController>>();
            _sut = new BooksController(_bookProviderMock.Object,_bookProviderLoggerMock.Object);
            
        }
        [Fact]
        public void GetBooksByTitle_ReturnsOkResult()
        {
            _bookProviderMock.Setup(x => x.GetBooksByTitle(It.IsAny<string>())).ReturnsAsync(new List<Book>() { new Book {
                Title= "Test",
                Author= "Test",
                Genre= Genre.Fantasy,
                Language= "English",
                PageAmount= 100,
                ISBN= 123456789
            } });
            


            //// Act
            var result = _sut.GetBooksByTitle("Title");
            
            //// Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            //result.Result.Should().BeOfType<>();
            //result.Result[0].Title.Should().Be("Test");
            //result.Result[0].Author.Should().Be("Test");
            //result.Result[0].Genre.Should().Be(Genre.Fantasy);
            //result.Result[0].Language.Should().Be("English");
            //result.Result[0].PageAmount.Should().Be(100);
            //result.Result[0].ISBN.Should().Be(123456789);
        }
    }
}