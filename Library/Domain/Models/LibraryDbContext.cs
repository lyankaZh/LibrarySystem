using System.Data.Entity;
using Domain.Models;

namespace Domain.Models
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("LibraryDb")
        {
            Database.SetInitializer(new LibraryDbInitializer());
        }

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
            base.Seed(context);
        }
    }
}
