using System;
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
    public partial class BorrowWindow : Window
    {
        private IUnitOfWork _unitOfWork;
        private BorrowInfoDisplayViewModel _borrowInfoDisplayViewModel;

        public BorrowWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _borrowInfoDisplayViewModel = new BorrowInfoDisplayViewModel(_unitOfWork);
            if (_borrowInfoDisplayViewModel.BorrowInfo.Any())
            {
                DataContext = _borrowInfoDisplayViewModel;
            }
            else
            {
                borrowTable.Visibility = Visibility.Hidden;
               
            }
        }


       private void markCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (borrowTable != null)
            {
                var selectedItem = borrowTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void markCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Has reader returned book?", "Mark Confirmation",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MarkAsReturned();
            }
        }
        private void deleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (borrowTable != null)
            {
                var selectedItem = borrowTable.SelectedItem;
                e.CanExecute = selectedItem != null;
            }
        }

        private void deleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DeleteBorrowInfo();
            }
        }

        public void DeleteBorrowInfo()
        {
            var borrowInfo = borrowTable.SelectedItem as BorrowInfo;
            if (borrowInfo != null)
            {
                var info = _unitOfWork.BorrowInfoRepository.GetById(borrowInfo.OrderId);
                _unitOfWork.BorrowInfoRepository.Delete(info);
                _unitOfWork.Save();
                _borrowInfoDisplayViewModel.BorrowInfo =
                    new ObservableCollection<BorrowInfo>(_unitOfWork.BorrowInfoRepository.Get().ToList());
            }
        }

        public void MarkAsReturned()
        {
            var borrowInfo = borrowTable.SelectedItem as BorrowInfo;
            if (borrowInfo != null)
            {
                var info = _unitOfWork.BorrowInfoRepository.GetById(borrowInfo.OrderId);
                info.ReturningDate = DateTime.Now;
                _unitOfWork.BorrowInfoRepository.Update(info);
                _unitOfWork.Save();
                _borrowInfoDisplayViewModel.BorrowInfo =
                    new ObservableCollection<BorrowInfo>(_unitOfWork.BorrowInfoRepository.Get().ToList());
            }
        }

        private void deptorsButton_Click(object sender, RoutedEventArgs e)
        {
            if (deptorsButton.Content.ToString() == "Deptors")
            {
                _borrowInfoDisplayViewModel.BorrowInfo =
                    new ObservableCollection<BorrowInfo>(
                        _unitOfWork.BorrowInfoRepository.Get(x => x.ReturningDate == null));

                deptorsButton.Content = "Show all";
            }
            else
            {
                _borrowInfoDisplayViewModel.BorrowInfo =
                    new ObservableCollection<BorrowInfo>(
                        _unitOfWork.BorrowInfoRepository.Get());
                deptorsButton.Content = "Deptors";

            }
        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var borrowCreatingWindow = new AddOrderWindow(_unitOfWork, _borrowInfoDisplayViewModel);
            borrowCreatingWindow.ShowDialog();
        }
    }
}
