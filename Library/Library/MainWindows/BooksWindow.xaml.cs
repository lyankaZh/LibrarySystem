using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.MainWindows
{
    public partial class BooksWindow : Window
    {
        readonly IUnitOfWork _unitOfWork;
        private BooksDisplayViewModel _booksDisplayViewModel;


        public BooksWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _booksDisplayViewModel = new BooksDisplayViewModel(this._unitOfWork);
            DataContext = _booksDisplayViewModel;
            DisplayTable();
        }
        
        public void DisplayTable()
        {
            if (_unitOfWork.BookRepository.Get().Any())
            {
                var booksToDisplay =
                    from book in _unitOfWork.BookRepository.Get()
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
                //booksTable.ItemsSource = booksToDisplay.ToList();
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
            AddWindows.AddNewBookWindow bookCreatingWindow = new AddWindows.AddNewBookWindow(_unitOfWork, _booksDisplayViewModel);
            bookCreatingWindow.ShowDialog();
        }
    }
}
