using System.ComponentModel.DataAnnotations;

namespace Template.API.Core.Models
{
    public class Book
    {
        [Key]
        public double ISBN { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string Language { get; set; } = string.Empty;
        public int PageAmount { get; set; }
    }

    public enum Genre
    {
        Action,
        Adventure,
        Classics,
        ComicBook,
        GraphicNovel,
        Detective,
        Mystery,
        Fantasy,
        HistoricalFiction,
        Horror,
        LiteraryFiction,
        Romance,
        ScienceFiction,
        ShortStory,
        Suspense,
        Thriller,
        Biographies,
        Autobiographies,
        History,
        SelfHelp,
        Health,
        Guide,
        Travel,
        Childrens,
        Religion,
        Spirituality,
        Science,
        Math,
        Anthology,
        Poetry,
        Encyclopedias,
        Dictionaries,
        Comics,
        Art,
        Cookbooks,
        Diaries,
        Journals,
        PrayerBooks,
        Series,
        Trilogy,
        YoungAdult,
        Crime,      
        Paranormal,
        Biography,
        Autobiography,
        
    }
}