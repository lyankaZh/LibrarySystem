using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                var criterias = new List<string>
                {
                    "Book", "Author", "Genre", "Publisher", "Language", "Year"
                };
               searchCriteriaComboBox.ItemsSource = criterias;
            }
            else
            {
                booksTable.Visibility = Visibility.Hidden;
                searchTextTextBox.Visibility = Visibility.Hidden;
                searchCriteriaComboBox.Visibility = Visibility.Hidden;
            }

        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookCreatingWindow = new AddNewBookWindow(_unitOfWork, _booksDisplayViewModel);
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
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation",
                MessageBoxButton.YesNo);
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
                var bookCreatingWindow = new AddNewBookWindow(_unitOfWork, _booksDisplayViewModel, bookModel);
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

        public void RemoveText()
        {
            searchTextTextBox.Text = "";
        }

        public void AddText()
        {
            if (String.IsNullOrWhiteSpace(searchTextTextBox.Text))
            {
                searchTextTextBox.Text = "Enter text here...";
            }
        }

        private void searchTextTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RemoveText();
        }

        private void searchTextTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AddText();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchButton.Content != null && searchButton.Content.ToString() == "Search")
            {
                var criteria = searchCriteriaComboBox.SelectedItem;
                if (criteria == null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(criteria.ToString()) && searchTextTextBox.Text != "Enter text here...")
                {
                    switch (criteria.ToString())
                    {
                        case "Book":
                            _booksDisplayViewModel.Books = new ObservableCollection<BookModel>(
                                              _unitOfWork.BookRepository.Get(x => x.Name.ToLower()
                                              .Contains(searchTextTextBox.Text.ToLower())).ToList()
                                              .ToBookModelsList(_unitOfWork));
                            break;

                        case "Author":
                            var authorsList = new List<Book>();
                            foreach (var book in _unitOfWork.BookRepository.Get())
                            {
                                foreach (var author in book.Authors)
                                {
                                    if (author.FirstName.ToLower().Contains(searchTextTextBox.Text.ToLower())
                                        || author.LastName.ToLower().Contains(searchTextTextBox.Text.ToLower()))
                                    {
                                        authorsList.Add(book);
                                    }
                                    else if (author.MiddleName?.ToLower().Contains(searchTextTextBox.Text.ToLower()) == true)
                                    {
                                        authorsList.Add(book);
                                    }
                                }
                            }

                            _booksDisplayViewModel.Books = new ObservableCollection<BookModel>(
                                authorsList.ToBookModelsList(_unitOfWork));

                            break;

                        case "Genre":
                            _booksDisplayViewModel.Books =
                        new ObservableCollection<BookModel>(
                            _unitOfWork.BookRepository.Get(x => x.Genre.GenreName.ToLower()
                            .Contains(searchTextTextBox.Text.ToLower())).ToList()
                            .ToBookModelsList(_unitOfWork));
                            break;

                        case "Language":
                            _booksDisplayViewModel.Books =
                        new ObservableCollection<BookModel>(
                            _unitOfWork.BookRepository.Get(x => x.Language.LanguageName.ToLower()
                            .Contains(searchTextTextBox.Text.ToLower())).ToList()
                            .ToBookModelsList(_unitOfWork));
                            break;

                        case "Publisher":
                            _booksDisplayViewModel.Books =
                        new ObservableCollection<BookModel>(
                            _unitOfWork.BookRepository.Get(x => x.Publisher.PublisherName.ToLower()
                            .Contains(searchTextTextBox.Text.ToLower())).ToList()
                            .ToBookModelsList(_unitOfWork));
                            break;

                        case "Year":
                            var year = 0;
                            if (int.TryParse(searchTextTextBox.Text, out year))
                            {
                                _booksDisplayViewModel.Books =
                                    new ObservableCollection<BookModel>(
                                            _unitOfWork.BookRepository.Get(x => x.Year == year).ToList()
                                        .ToBookModelsList(_unitOfWork));
                            }
                            break;
                    }

                    searchButton.Content = "Show all";
                }
            }
            else
            {
                _booksDisplayViewModel.Books =
                                     new ObservableCollection<BookModel>(
                                             _unitOfWork.BookRepository.Get().ToList()
                                         .ToBookModelsList(_unitOfWork));
                searchButton.Content = "Search";
                searchCriteriaComboBox.Text = "";
                searchTextTextBox.Text = "Enter text here...";
            }
        }
    }


}
