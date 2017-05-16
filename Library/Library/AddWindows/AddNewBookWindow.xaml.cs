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
    public partial class AddNewBookWindow
    {
        private readonly IUnitOfWork unitOfWork;
        readonly CreatingBookViewModel _creatingBookViewModel;
        private readonly BooksDisplayViewModel _booksDisplayViewModel;

        private readonly double marginTopValue = 5;

        public AddNewBookWindow(IUnitOfWork unitOfWork, BooksDisplayViewModel booksDisplayViewModel)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            _creatingBookViewModel = new CreatingBookViewModel(this.unitOfWork);
            _booksDisplayViewModel = booksDisplayViewModel;
            DataContext = _creatingBookViewModel;
            //InitializeComboBoxes();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreAllFieldsValid())
            {
                var genre = ((Genre) genreComboBox.SelectedItem);
                if (genre == null)
                {
                    MessageBox.Show("Вибрано неправильний жанр");
                    return;
                }

                var language = (Language) languageComboBox.SelectedItem;
                if (language == null)
                {
                    MessageBox.Show("Вибрано неправильну мову");
                    return;
                }

                var publisher = (Publisher) publisherComboBox.SelectedItem;
                if (publisher == null)
                {
                    MessageBox.Show("Вибрано неправильне видавництво");
                    return;
                }

                var name = nameTextBox.Text;
                var pages = int.Parse(pagesTextBox.Text);
                var year = int.Parse(yearTextBox.Text);
                var location = locationTextBox.Text;

                List<Author> authors = new List<Author>();
                foreach (ComboBox control in stackPanel.Children)
                {
                    var author = (Author)control.SelectedItem;
                    if (author == null)
                    {
                        MessageBox.Show("Вибрано неправильного автора");
                        return;
                    }
                    authors.Add(author);
                }

                Book book = new Book
                {
                    Name = name,
                    Genre = unitOfWork.GenreRepository.GetById(genre.GenreId),
                    Language = unitOfWork.LanguageRepository.GetById(language.LanguageId),
                    Publisher = unitOfWork.PublisherRepository.GetById(publisher.PublisherId),
                    Location = location,
                    Year = year,
                    Pages = pages,
                    Authors = authors
                };
                unitOfWork.BookRepository.Insert(book);

                foreach (var a in authors)
                {
                    a.Books.Add(book);
                    unitOfWork.AuthorRepository.Update(a);
                }
                unitOfWork.Save();
                _booksDisplayViewModel.Books = 
                    new ObservableCollection<BookModel>(unitOfWork.BookRepository.Get().ToList().ToBookModelsList(unitOfWork));
                Close();
            }
            else
            {
                MessageBox.Show("Введено неправильні дані");
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

        //private void InitializeComboBoxes()
        //{
        //    //var languages = from lan in unitOfWork.LanguageRepository.Get() select lan.LanguageName;
        //    //languageComboBox.ItemsSource = languages;

        //    //var genres = from g in unitOfWork.GenreRepository.Get() select g.GenreName;
        //    //genreComboBox.ItemsSource = genres;

        //    //var publishers = from p in unitOfWork.PublisherRepository.Get() select p.PublisherName;
        //    //publisherComboBox.ItemsSource = publishers;
        //    //ObservableCollection<Genre> genres = new ObservableCollection<Genre>(unitOfWork.GenreRepository.Get());
          
        //    //genreComboBox.ItemsSource = genreViewModel.Genres;
        //    languageComboBox.ItemsSource = unitOfWork.LanguageRepository.Get();
        //    //genreComboBox.ItemsSource = unitOfWork.GenreRepository.Get();
        //    //genreComboBox.ItemsSource = genres;
        //    publisherComboBox.ItemsSource = unitOfWork.PublisherRepository.Get();
        //    authorComboBox.ItemsSource = unitOfWork.AuthorRepository.Get();


        //}

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewGenreWindow addNewGenreWindow = new AddNewGenreWindow(_creatingBookViewModel, unitOfWork);
            addNewGenreWindow.ShowDialog();
        }

        private void addPublisherButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewPublisherWindow addNewGenreWindow = new AddNewPublisherWindow(_creatingBookViewModel, unitOfWork);
            addNewGenreWindow.ShowDialog();
        }

        private void addLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewLanguageWindow addNewLanguageWindow = new AddNewLanguageWindow(_creatingBookViewModel, unitOfWork);
            addNewLanguageWindow.ShowDialog();
        }

        private void addAuthor_Click(object sender, RoutedEventArgs e)
        {
            AddNewAuthorWindow addNewAuthorWindow = new AddNewAuthorWindow(_creatingBookViewModel);
            addNewAuthorWindow.ShowDialog();
        }

        private void oneMoreAuthor_Click(object sender, RoutedEventArgs e)
        {
            AddNewBook.Height += 25;
            mainGrid.Height += 25;
            stackPanel.Height += 25;
            stackPanelRemove.Height += 25;

            MoveControlDown(saveButton, 25);
            MoveControlDown(cancelButton, 25);
            MoveControlDown(oneMoreAuthor, 25);

            //TextBox lastTextBox = (TextBox)authorsGrid.Children[authorsGrid.Children.Count - 1];

            //var marginForNewButton = lastTextBox.Margin;
            //marginForNewButton.Top += 20;

            ComboBox newAuthorComboBox = new ComboBox();
            newAuthorComboBox.HorizontalAlignment = HorizontalAlignment.Left;
            newAuthorComboBox.Margin = new Thickness(0,marginTopValue,0,0);
            newAuthorComboBox.Height = 20;
            newAuthorComboBox.Width = 105;
            Binding b = new Binding("Authors")
            {
                Source = DataContext
            };
            newAuthorComboBox.SetBinding(ComboBox.ItemsSourceProperty, b);
            //newAuthorTextBox.ItemsSource = viewModel.Authors;
            newAuthorComboBox.IsEditable = true;

            stackPanel.Children.Add(newAuthorComboBox);

            Button removeButton = new Button();
            removeButton.Height = 20;
            removeButton.Content = "Забрати";
            removeButton.Margin = new Thickness(0, marginTopValue, 0, 0);
            removeButton.Click  += removeButton_Click;

            stackPanelRemove.Children.Add(removeButton);
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button) sender;
            int index = stackPanelRemove.Children.IndexOf(removeButton);
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
        
        //private void languageComboBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox) sender;
        //    var language = (Language) comboBox.SelectedItem;
        //    if (language == null)
        //    {
        //        //languageBorder.BorderBrush = Brushes.Red;

        //        saveButton.IsEnabled = false;
        //        saveButton.ToolTip = "Вибрана неіснуюча мова";
        //    }
        //    else
        //    {
        //        languageBorder.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFACACAC");
        //        saveButton.IsEnabled = true;
        //        saveButton.ClearValue(Button.ToolTipProperty);
        //    }   
        //}
    }
}
