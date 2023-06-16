using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Template.API.Core.Interfaces;
using Template.API.Core.Models;
using Template.API.Rest.Controllers;

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
            _sut = new BooksController(_bookProviderMock.Object, _bookProviderLoggerMock.Object);

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

            var resultObj = (result.Result as OkObjectResult).Value as List<Book>;
            //// Assert
            resultObj.Should().BeOfType<List<Book>>();

            resultObj[0].Title.Should().Be("Test");
            resultObj[0].Author.Should().Be("Test");
            resultObj[0].Genre.Should().Be(Genre.Fantasy);
            resultObj[0].Language.Should().Be("English");
            resultObj[0].PageAmount.Should().Be(100);
            resultObj[0].ISBN.Should().Be(123456789);
            resultObj.Count.Should().Be(1);

        }


        [Fact]
        public void GetAllBooks_ReturnsOkResult()
        {
            _bookProviderMock.Setup(x => x.GetAllBooks()).ReturnsAsync(new List<Book>() { new Book {
                Title= "Test",
                Author= "Test",
                Genre= Genre.Fantasy,
                Language= "English",
                PageAmount= 100,
                ISBN= 123456789
            }, new Book{
                Title= "Test2",
                Author= "Test2",
                Genre= Genre.Detective,
                Language= "English",
                PageAmount= 1000,
                ISBN= 1234567890
            } });


            var result = _sut.GetAllBooks();
            var resultObj = (result.Result as OkObjectResult).Value as List<Book>;
            resultObj.Count.Should().Be(2);
            resultObj[0].Title.Should().Be("Test");
            resultObj[0].Author.Should().Be("Test");
            resultObj[0].Genre.Should().Be(Genre.Fantasy);
            resultObj[0].Language.Should().Be("English");
            resultObj[0].PageAmount.Should().Be(100);
            resultObj[0].ISBN.Should().Be(123456789);
            resultObj[1].Title.Should().Be("Test2");
            resultObj[1].Author.Should().Be("Test2");
            resultObj[1].Genre.Should().Be(Genre.Detective);
            resultObj[1].Language.Should().Be("English");
            resultObj[1].PageAmount.Should().Be(1000);
            resultObj[1].ISBN.Should().Be(1234567890);
        }

        [Fact]
        public void GetBooksByAuthor_ReturnsOkResult()
        {
            _bookProviderMock.Setup(x => x.GetBooksByAuthor(It.IsAny<string>())).ReturnsAsync(new List<Book>() { new Book
            {
                Title= "Test",
                Author= "Test",
                Genre= Genre.Fantasy,
                Language= "English",
                PageAmount= 100,
                ISBN= 123456789
            } });

            //// Act
            var result = _sut.GetBooksByAuthor("Author");
            var resultObj = (result.Result as OkObjectResult).Value as List<Book>;

            //// Assert
            resultObj.Should().BeOfType<List<Book>>();
            resultObj[0].Title.Should().Be("Test");
            resultObj[0].Author.Should().Be("Test");
            resultObj[0].Genre.Should().Be(Genre.Fantasy);
            resultObj[0].Language.Should().Be("English");
            resultObj[0].PageAmount.Should().Be(100);
            resultObj[0].ISBN.Should().Be(123456789);
            resultObj.Count.Should().Be(1);
        }

        [Fact]
        public void GetBooksByGenre_ReturnsOkResult()
        {
            _bookProviderMock.Setup(x => x.GetBooksByGenre(It.IsAny<Genre>())).ReturnsAsync(new List<Book>() { new Book
            {
                Title= "Test",
                Author= "Test",
                Genre= Genre.Fantasy,
                Language= "English",
                PageAmount= 100,
                ISBN= 123456789
            } });
            // Act
            var result = _sut.GetBooksByGenre(Genre.Fantasy);
            var resultObj = (result.Result as OkObjectResult).Value as List<Book>;

            //// Assert
            resultObj.Should().BeOfType<List<Book>>();
            resultObj[0].Title.Should().Be("Test");
            resultObj[0].Author.Should().Be("Test");
            resultObj[0].Genre.Should().Be(Genre.Fantasy);
            resultObj[0].Language.Should().Be("English");
            resultObj[0].PageAmount.Should().Be(100);
            resultObj[0].ISBN.Should().Be(123456789);
            resultObj.Count.Should().Be(1);
        }
    }
}


