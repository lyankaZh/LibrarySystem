using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Domain.Models;
using Domain.Repository;
using Library.AddWindows;
using Library.Helpers;
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
            _booksDisplayViewModel = new BooksDisplayViewModel(_unitOfWork);
            if (_booksDisplayViewModel.Books.Any())
            {
                DataContext = _booksDisplayViewModel;
            }
            else
            {
                booksTable.Visibility = Visibility.Hidden;
            }
        }

        //public void DisplayTable()
        //{
        //    if (_unitOfWork.BookRepository.Get().Any())
        //    {
        //        var booksToDisplay =
        //            from book in _unitOfWork.BookRepository.Get()
        //            select new
        //            {
        //                BookId = book.BookId,
        //                Name = book.Name,
        //                Year = book.Year,
        //                Pages = book.Pages,
        //                Location = book.Location,
        //                Genre = book.Genre.GenreName,
        //                Language = book.Language.LanguageName,
        //                Publisher = book.Publisher.PublisherName,
        //                //CHANGE
        //                IsInLibrary = "Так",
        //                Authors = MakeStringFromListOfAuthors(book.Authors)
        //            };
        //        //booksTable.ItemsSource = booksToDisplay.ToList();
        //    }
        //    else
        //    {
        //        booksTable.Visibility = Visibility.Hidden;
        //    }
        //}

        //private string MakeStringFromListOfAuthors(List<Author> list)
        //{
        //    if (list != null)
        //    {
        //        StringBuilder stringToReturn = new StringBuilder();
        //        foreach (var author in list)
        //        {
        //            stringToReturn.Append($"{author},");
        //        }
        //        stringToReturn = stringToReturn.Remove(stringToReturn.Length - 1, 1);
        //        return stringToReturn.ToString();
        //    }
        //    return "";
        //}

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookCreatingWindow = new AddWindows.AddNewBookWindow(_unitOfWork, _booksDisplayViewModel);
            bookCreatingWindow.ShowDialog();
        }

        private void editCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (booksTable != null)
            {
                var selectedItem = booksTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void editCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditBook();
        }
        private void deleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (booksTable != null)
            {
                var selectedItem = booksTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void deleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation",
                System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DeleteBook();
            }
        }

        public void EditBook()
        {
            var bookModel = booksTable.SelectedItem as BookModel;
            if (bookModel != null)
            {
                var bookCreatingWindow = new AddWindows.AddNewBookWindow(_unitOfWork, _booksDisplayViewModel, bookModel);
                bookCreatingWindow.ShowDialog();
            }
        }

        public void DeleteBook()
        {
            var bookModel = booksTable.SelectedItem as BookModel;
            if (bookModel != null)
            {
                var book = _unitOfWork.BookRepository.GetById(bookModel.BookId);
                _unitOfWork.BookRepository.Delete(book);
                _unitOfWork.Save();
                _booksDisplayViewModel.Books =
                    new ObservableCollection<BookModel>(_unitOfWork.BookRepository.Get().ToList().ToBookModelsList(_unitOfWork));
            }
        }
    }


}
