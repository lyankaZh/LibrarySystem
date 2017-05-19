using System.Windows;
using Domain.Repository;
using Library.MainWindows;

namespace Library
{
    public partial class MainWindow:Window
    {
        IUnitOfWork unitOfWork = new UnitOfWork();

        public MainWindow()
        {
            InitializeComponent();
            #region Comments
            //  unitOfWork.LanguageRepository.Insert(new Language()
            //  {
            //      LanguageId = 1,
            //      LanguageName = "Українська"
            //  });

            //  unitOfWork.GenreRepository.Insert(new Genre()
            //  {
            //      GenreId = 2,
            //      GenreName = "Математика"
            //  });

            //  unitOfWork.PublisherRepository.Insert(new Publisher()
            //  {
            //      PublisherId = 1,
            //      City = "Львів",
            //      Country = "Україна",
            //      PublisherName = "Видавначий центр ЛНУ"
            //  });

            //  unitOfWork.AuthorRepository.Insert(new Author()
            //  {
            //      AuthorId = 1,
            //      FirstName = "Григорій",
            //      LastName = "Цегелик"
            //  });
            //  List<Author> authors = new List<Author>();
            //  authors.Add(unitOfWork.AuthorRepository.GetById(1));

            //  unitOfWork.BookRepository.Insert(new Book()
            //{
            //    BookId = 1,
            //    Genre = unitOfWork.GenreRepository.GetById(2),
            //    Language = unitOfWork.LanguageRepository.GetById(1),
            //    Publisher = unitOfWork.PublisherRepository.GetById(1),
            //    Pages = 407,
            //    Location = "1.2.1",
            //    Name = "",
            //    Year = 2004,
            //    Authors = authors
            //});
            //  unitOfWork.Save();

            //  //var author = unitOfWork.AuthorRepository.GetById(1);
            //  //author.Books.Add(unitOfWork.BookRepository.GetById(1));
            //  //unitOfWork.AuthorRepository.Update(author);

            //  //unitOfWork.Save();


            #endregion
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            var booksWindow = new BooksWindow(unitOfWork);
            booksWindow.ShowDialog();
        }

        private void readersButton_Click(object sender, RoutedEventArgs e)
        {
            var readersWindow = new ReadersWindow(unitOfWork);
            readersWindow.ShowDialog();
        }

        private void borrowButton_Click(object sender, RoutedEventArgs e)
        {
            var borrowInfo = new BorrowWindow(unitOfWork);
            borrowInfo.ShowDialog();
        }
    }
}
