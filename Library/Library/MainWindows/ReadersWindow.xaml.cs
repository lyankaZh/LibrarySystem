using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Domain.Models;
using Domain.Repository;
using Library.AddWindows;
using Library.ViewModels;

namespace Library.MainWindows
{
   public partial class ReadersWindow : Window
    {
        readonly IUnitOfWork _unitOfWork;
        private ReadersDisplayViewModel _readersDisplayViewModel;

        public ReadersWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _readersDisplayViewModel = new ReadersDisplayViewModel(_unitOfWork);
            if (_readersDisplayViewModel.Readers.Any())
            {
                DataContext = _readersDisplayViewModel;
                var criterias = new List<string>
                {
                    "FirstName", "LastName", "MiddleName", "Address", "Phonenumber"
                };
                searchCriteriaComboBox.ItemsSource = criterias;
            }
            else
            {
                readersTable.Visibility = Visibility.Hidden;
                searchTextTextBox.Visibility = Visibility.Hidden;
                searchCriteriaComboBox.Visibility = Visibility.Hidden;
            }
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            var readerCreatingWindow = new AddNewReaderWindow(_unitOfWork, _readersDisplayViewModel);
            readerCreatingWindow.ShowDialog();
        }

        private void editCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (readersTable != null)
            {
                var selectedItem = readersTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void editCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditReader();
        }
        private void deleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (readersTable != null)
            {
                var selectedItem = readersTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void deleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DeleteReader();
            }
        }

        public void EditReader()
        {
            var reader = readersTable.SelectedItem as Reader;
            if (reader != null)
            {
                var readersAddingWindow = new AddNewReaderWindow(_unitOfWork, _readersDisplayViewModel, reader);
                readersAddingWindow.ShowDialog();
            }
        }

        public void DeleteReader()
        {
            var reader = readersTable.SelectedItem as Reader;
            if (reader != null)
            {
               
                _unitOfWork.ReaderRepository.Delete(reader);
                _unitOfWork.Save();
                _readersDisplayViewModel.Readers =
                    new ObservableCollection<Reader>(_unitOfWork.ReaderRepository.Get());
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
                        case "FirstName":
                            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(
                                              _unitOfWork.ReaderRepository.Get(x => x.FirstName.ToLower()
                                              .Contains(searchTextTextBox.Text.ToLower())));
                            break;

                        case "LastName":
                            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(
                                              _unitOfWork.ReaderRepository.Get(x => x.LastName.ToLower()
                                              .Contains(searchTextTextBox.Text.ToLower())));
                            break;

                        case "Address":
                            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(
                                             _unitOfWork.ReaderRepository.Get(x => x.Address.ToLower()
                                             .Contains(searchTextTextBox.Text.ToLower())));
                            break;

                        case "Phonenumber":
                            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(
                                           _unitOfWork.ReaderRepository.Get(x => x.PhoneNumber.ToLower()
                                           .Contains(searchTextTextBox.Text.ToLower())));
                            break;

                      
                    }

                    searchButton.Content = "Show all";
                }
            }
            else
            {
                _readersDisplayViewModel.Readers =
                                     new ObservableCollection<Reader>(
                                             _unitOfWork.ReaderRepository.Get());
                searchButton.Content = "Search";
                searchCriteriaComboBox.Text = "";
                searchTextTextBox.Text = "Enter text here...";
            }
        }
    }
}
