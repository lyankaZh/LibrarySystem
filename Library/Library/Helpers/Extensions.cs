using System.Collections.Generic;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.Helpers
{
    public static class Extensions
    {
        public static List<BookModel> ToBookModelsList(this IEnumerable<Book> books, IUnitOfWork unitOfWork)
        {
            var booksModels = new List<BookModel>();
            foreach (var book in books)
            {
                booksModels.Add(
                    new BookModel
                    {
                        Authors = new AuthorsList(book.Authors),
                        BookId = book.BookId,
                        Genre = book.Genre.ToString(),
                        IsInLibrary = LibraryHelper.IsInLibrary(book, unitOfWork) ? "yes" : "no",
                        Language = book.Language.ToString(),
                        Location = book.Location,
                        Name = book.Name,
                        Pages = book.Pages,
                        Publisher = book.Publisher.ToString(),
                        Year = book.Year
                    });
            
            }
            return booksModels;
        }
    }
}
