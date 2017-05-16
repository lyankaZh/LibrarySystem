using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Models;
using Domain.Repository;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOfWork unitOfWork = new UnitOfWork();



        public MainWindow()
        {
            InitializeComponent();


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
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow();
            booksWindow.ShowDialog();
        }
    }
}
