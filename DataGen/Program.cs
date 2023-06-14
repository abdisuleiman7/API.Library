// See https://aka.ms/new-console-template for more information



using Template.API.Core.Models;
using Template.API.Infrastructure.Data;

dataGeneration();
Console.WriteLine("Add book");

void dataGeneration()
{
    var books = new List<Book>
    {
        new Book {
        Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien",
        PageAmount = 800,
        ISBN = 9780007522903,
        Genre = Genre.Fantasy,
        Language = "English"
        },
        new Book
        {
            Title = "The Two Towers", Author = "J.R.R. Tolkien",
            PageAmount = 970,
            ISBN = 9780007522910,
            Genre = Genre.Fantasy,
            Language = "English"
        },
        new Book {
            Title ="The Return of the King", Author = "J.R.R. Tolkien",
            PageAmount = 1000,
            ISBN = 9780007522927,
            Genre = Genre.Fantasy,
            Language = "English"
                },
        new Book {
            Title = "The Hobbit", Author = "J.R.R. Tolkien",
            PageAmount = 500,
            ISBN = 9780007522934,
            Genre = Genre.Fantasy,
            Language = "English"
        },
        new Book
        {
            Title ="The Count Of Monte Cristo",
            Author = "Alexandre Dumas",
            PageAmount = 470,
            ISBN = 9780007522941,
            Genre = Genre.Adventure,
            Language = "French"
        }              
    };
    try
    {
        using (var context = new LibraryContext())
        {
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {

        throw new Exception($"Database Error:{ex}");
    }
    
}

