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
using System.Windows.Shapes;
using Domain.Models;
using Domain.Repository;


namespace Library
{
    /// <summary>
    /// Interaction logic for BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public BooksWindow()
        {
            InitializeComponent();
            DisplayTable();
        }


        public void DisplayTable()
        {
            if (unitOfWork.BookRepository.Get().Any())
            {
                var booksToDisplay =
                    from book in unitOfWork.BookRepository.Get()
                    select new 
                    {
                        BookId = book.BookId,
                        Name = book.Name,
                        Year = book.Year,
                        Pages = book.Pages,
                        Location = book.Location,
                        Genre = book.Genre.GenreName,
                        Language = book.Language.LanguageName,
                        Publisher = book.Publisher.PublisherName,
                        //CHANGE
                        IsInLibrary = "Так",
                        Authors = MakeStringFromListOfAuthors(book.Authors)
                    };
                booksTable.ItemsSource = booksToDisplay.ToList();
            }
            else
            {
                booksTable.Visibility = Visibility.Hidden;
                
            }
        }


        private string MakeStringFromListOfAuthors(List<Author> list)
        {
            if (list != null)
            {
                StringBuilder stringToReturn = new StringBuilder();
                foreach (var author in list)
                {
                    stringToReturn.Append($"{author},");
                }
                stringToReturn = stringToReturn.Remove(stringToReturn.Length - 1, 1);
                return stringToReturn.ToString();
            }
            return "";
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookCreatingWindow bookCreatingWindow = new BookCreatingWindow();
            bookCreatingWindow.ShowDialog();
        }
    }
}
