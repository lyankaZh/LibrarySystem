using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.Helpers;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddOrderWindow
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BorrowInfoDisplayViewModel _borrowDisplayViewModel;

        public AddOrderWindow(IUnitOfWork unitOfWork, BorrowInfoDisplayViewModel borrowDisplayViewModel)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _borrowDisplayViewModel = borrowDisplayViewModel;
            readerComboBox.ItemsSource = _unitOfWork.ReaderRepository.Get();
            bookComboBox.ItemsSource =
                _unitOfWork.BookRepository.Get().Where(x => LibraryHelper.IsInLibrary(x, _unitOfWork));
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreTextFieldsValid())
            {
                
                var reader = _unitOfWork.ReaderRepository.GetById(readerComboBox.SelectedValue);
                
                if (reader == null)
                {
                    MessageBox.Show("Incorrect reader");
                    return;
                }

                var book = _unitOfWork.BookRepository.GetById(bookComboBox.SelectedValue);
                if (book == null)
                {
                    MessageBox.Show("Incorrect book");
                    return;
                }

                var borrowInfo = new BorrowInfo
                {
                    Reader = reader,
                    Book = book,
                    BorrowPeriodInDays = int.Parse(periodTextBox.Text),
                    BorrowDate = DateTime.Now
                };

                _unitOfWork.BorrowInfoRepository.Insert(borrowInfo);
                _unitOfWork.Save();
                _borrowDisplayViewModel.BorrowInfo
                    =
                    new ObservableCollection<BorrowInfo>(_unitOfWork.BorrowInfoRepository.Get().ToList());
                Close();
            }
            else
            {
                MessageBox.Show("Check your values");
            }
        }

        private bool AreTextFieldsValid()
        {
            int result;
            if (readerComboBox.SelectedValue == null)
            {
                return false;
            }
            if (bookComboBox.SelectedValue == null)
            {
                return false;
            }
           
            return int.TryParse(periodTextBox.Text, out result);
        }
    }
}
