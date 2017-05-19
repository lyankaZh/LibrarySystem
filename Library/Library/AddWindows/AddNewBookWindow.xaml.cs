using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Domain.Models;
using Domain.Repository;
using Library.Helpers;
using Library.ViewModels;

namespace Library.AddWindows
{
    public enum OperationType
    {
        Create,
        Edit
    }


    public partial class AddNewBookWindow
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly CreatingBookViewModel _creatingBookViewModel;
        private readonly BooksDisplayViewModel _booksDisplayViewModel;
        private readonly int _editedBookId;
        private readonly OperationType _operationType;

        private readonly double marginTopValue = 5;

        public AddNewBookWindow(IUnitOfWork unit, BooksDisplayViewModel booksDisplayViewModel)
        {
            InitializeComponent();
            _unitOfWork = unit;
            _creatingBookViewModel = new CreatingBookViewModel(_unitOfWork);
            _booksDisplayViewModel = booksDisplayViewModel;
            DataContext = _creatingBookViewModel;
            _operationType = OperationType.Create;
        }

        public AddNewBookWindow(IUnitOfWork unit, BooksDisplayViewModel booksDisplayViewModel, BookModel bookModel)
        {
            InitializeComponent();
            _unitOfWork = unit;
            _creatingBookViewModel = new CreatingBookViewModel(_unitOfWork);
            _booksDisplayViewModel = booksDisplayViewModel;
            DataContext = _creatingBookViewModel;
            _operationType = OperationType.Edit;
            _editedBookId = bookModel.BookId;
            SetInitialTextOnTextBoxes(bookModel);
        }


        private void SetInitialTextOnTextBoxes(BookModel bookModel)
        {
            nameTextBox.Text = bookModel.Name;
            yearTextBox.Text = bookModel.Year.ToString();
            pagesTextBox.Text = bookModel.Pages.ToString();
            locationTextBox.Text = bookModel.Location;
            genreComboBox.SelectedValue = bookModel.Genre;
            languageComboBox.SelectedValue = bookModel.Language;
            publisherComboBox.SelectedValue = bookModel.Publisher;
           
            authorComboBox.SelectedValue = bookModel.Authors.Authors[0].AuthorId;

            for (var i = 1; i < bookModel.Authors.Authors.Count; i++)
            {
                CreateNewComboBox().SelectedValue = bookModel.Authors.Authors[i].AuthorId;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreAllFieldsValid())
                {
                    var genre = ((Genre) genreComboBox.SelectedItem);
                    if (genre == null)
                    {
                        MessageBox.Show("Incorrect genre");
                        return;
                    }

                    var language = (Language) languageComboBox.SelectedItem;
                    if (language == null)
                    {
                        MessageBox.Show("Incorrect language");
                        return;
                    }

                    var publisher = (Publisher) publisherComboBox.SelectedItem;
                    if (publisher == null)
                    {
                        MessageBox.Show("Incorrect publisher");
                        return;
                    }

                    var name = nameTextBox.Text;
                    var pages = int.Parse(pagesTextBox.Text);
                    var year = int.Parse(yearTextBox.Text);
                    var location = locationTextBox.Text;

                    var authors = new List<Author>();
                    foreach (ComboBox control in stackPanel.Children)
                    {
                        var author = (Author) control.SelectedItem;
                        if (author == null)
                        {
                            MessageBox.Show("Incorrect author");
                            return;
                        }
                        authors.Add(author);
                    }

                    var book = new Book
                    {
                        Name = name,
                        Genre = _unitOfWork.GenreRepository.GetById(genre.GenreId),
                        Language = _unitOfWork.LanguageRepository.GetById(language.LanguageId),
                        Publisher = _unitOfWork.PublisherRepository.GetById(publisher.PublisherId),
                        Location = location,
                        Year = year,
                        Pages = pages,
                        Authors = authors
                    };

                    if (_operationType == OperationType.Create)
                    {
                        AddBook(book, authors);
                    }
                    else if (_operationType == OperationType.Edit)
                    {
                        EditBook(book);
                    }

                    _unitOfWork.Save();
                    _booksDisplayViewModel.Books =
                        new ObservableCollection<BookModel>(
                            _unitOfWork.BookRepository.Get().ToList().ToBookModelsList(_unitOfWork));
                    Close();

                }
                else
                {
                    MessageBox.Show("Incorrect values");
                }
            }
            catch
            {
                MessageBox.Show("Opps...Smth went wrong. Try again later");
            }
        }


        public void AddBook(Book book, List<Author> authors)
        {   
            _unitOfWork.BookRepository.Insert(book);

            foreach (var a in authors)
            {
                a.Books.Add(book);
                _unitOfWork.AuthorRepository.Update(a);
            }
          
        }

        public void EditBook(Book newBook)
        {
            var bookToChange = _unitOfWork.BookRepository.GetById(_editedBookId);
            if (bookToChange != null)
            {
                bookToChange.Authors = newBook.Authors;
                bookToChange.Genre = newBook.Genre;
                bookToChange.Language = newBook.Language;
                bookToChange.Location = newBook.Location;
                bookToChange.Name = newBook.Name;
                bookToChange.Pages = newBook.Pages;
                bookToChange.Publisher = newBook.Publisher;
                bookToChange.Year = newBook.Year;

                _unitOfWork.BookRepository.Update(bookToChange);
            }
        }

        private bool AreAllFieldsValid()
        {
            int result;
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                return false;
            }
            if (!int.TryParse(yearTextBox.Text, out result))
            {
                return false;
            }
            if (!int.TryParse(pagesTextBox.Text, out result))
            {
                return false;
            }
            if (string.IsNullOrEmpty(locationTextBox.Text))
            {
                return false;
            }
            if (genreComboBox.SelectedValue == null)
            {
                return false;
            }
            if (languageComboBox.SelectedValue == null)
            {
                return false;
            }
            if (publisherComboBox.SelectedValue == null)
            {
                return false;
            }
            return true;
        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewGenreWindow = new AddNewGenreWindow(_creatingBookViewModel, _unitOfWork);
            addNewGenreWindow.ShowDialog();
        }

        private void addPublisherButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewGenreWindow = new AddNewPublisherWindow(_creatingBookViewModel, _unitOfWork);
            addNewGenreWindow.ShowDialog();
        }

        private void addLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewLanguageWindow = new AddNewLanguageWindow(_creatingBookViewModel, _unitOfWork);
            addNewLanguageWindow.ShowDialog();
        }

        private void addAuthor_Click(object sender, RoutedEventArgs e)
        {
            var addNewAuthorWindow = new AddNewAuthorWindow(_creatingBookViewModel);
            addNewAuthorWindow.ShowDialog();
        }

        private void oneMoreAuthor_Click(object sender, RoutedEventArgs e)
        {
            CreateNewComboBox();
        }

        public ComboBox CreateNewComboBox()
        {
            AddNewBook.Height += 25;
            mainGrid.Height += 25;
            stackPanel.Height += 25;
            stackPanelRemove.Height += 25;

            MoveControlDown(saveButton, 25);
            MoveControlDown(cancelButton, 25);
            MoveControlDown(oneMoreAuthor, 25);

            var newAuthorComboBox = new ComboBox();
            newAuthorComboBox.SelectedValuePath = "AuthorId";
            newAuthorComboBox.HorizontalAlignment = HorizontalAlignment.Left;
            newAuthorComboBox.Margin = new Thickness(0, marginTopValue, 0, 0);
            newAuthorComboBox.Height = 20;
            newAuthorComboBox.Width = 105;
            var b = new Binding("Authors")
            {
                Source = DataContext
            };
            newAuthorComboBox.SetBinding(ItemsControl.ItemsSourceProperty, b);
            newAuthorComboBox.IsEditable = true;

            stackPanel.Children.Add(newAuthorComboBox);

            var removeButton = new Button
            {
                Height = 20,
                Content = "Забрати",
                Margin = new Thickness(0, marginTopValue, 0, 0)
            };
            removeButton.Click += removeButton_Click;

            stackPanelRemove.Children.Add(removeButton);

            return newAuthorComboBox;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var removeButton = (Button) sender;
            var index = stackPanelRemove.Children.IndexOf(removeButton);
            stackPanel.Children.RemoveAt(index + 1);
            stackPanelRemove.Children.RemoveAt(index);
            AddNewBook.Height -= 25;
            mainGrid.Height -= 25;
            stackPanel.Height -= 25;
            stackPanelRemove.Height -= 25;

            MoveControlDown(saveButton, -25);
            MoveControlDown(cancelButton, -25);
            MoveControlDown(oneMoreAuthor, -25);
        }

        public void MoveControlDown(Control control, double valueToMove)
        {
            var margin = control.Margin;
            margin.Top += valueToMove;
            control.Margin = margin;
        }
    }
}
