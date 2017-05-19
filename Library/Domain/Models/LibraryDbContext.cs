using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Domain.Models
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("LibraryDb")
        {
            Database.SetInitializer(new LibraryDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowInfo> BorrowInfo { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }

    public class LibraryDbInitializer : DropCreateDatabaseIfModelChanges<LibraryDbContext>
    {
        protected override void Seed(LibraryDbContext context)
        {
            var user = new User
            {
                Login = "user",
                Password = Encryptor.Encrypt("123")
            };

            context.Users.Add(user);
            var reader = new Reader
            {
                Address = "Wall Str. 5/3",
                FirstName = "John",
                LastName = "Smith",
                PhoneNumber = "88005553535",
                RegistrationDate = DateTime.Now
            };

            context.Readers.Add(reader);

            var genre = new Genre {GenreName = "Adventures"};
            var language = new Language {LanguageName = "English"};
            var publisher = new Publisher {City = "Las Vegas", Country = "USA", PublisherName = "ABC"};

            context.Genres.Add(genre);
            context.Languages.Add(language);
            context.Publishers.Add(publisher);

            var author = new Author
            {
                FirstName = "Mark",
                LastName = "Twain"
            };

            var book = new Book
            {
                Name = "The Adventures of Tom Sawyer",
                Genre = genre,
                Language = language,
                Publisher = publisher,
                Location = "1.2.2",
                Pages = 200,
                Year = 1876,
                Authors = new List<Author> {author}
            };

            context.Authors.Add(author);
            context.Books.Add(book);
            var borrowInfo = new BorrowInfo
            {
                Book = book,
                Reader = reader,
                BorrowDate = DateTime.Now,
                BorrowPeriodInDays = 15
            };
            context.BorrowInfo.Add(borrowInfo);

            base.Seed(context);
        }
    }
}
