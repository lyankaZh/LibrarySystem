using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewAuthorWindow 
    {
        readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly CreatingBookViewModel _viewModel;

        public AddNewAuthorWindow( CreatingBookViewModel model)
        {
            InitializeComponent();
            _viewModel = model;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrEmpty(nameTextBox.Text))
            {
                var author =new Author
                {
                    FirstName = nameTextBox.Text,
                    LastName = surnameTextBox.Text
                };
                if (!string.IsNullOrEmpty(middleNameTextBox.Text))
                {
                    author.MiddleName = middleNameTextBox.Text;
                }
                _unitOfWork.AuthorRepository.Insert(author);
                _unitOfWork.Save();

                _viewModel.Authors = new ObservableCollection<Author>(_unitOfWork.AuthorRepository.Get().ToList());
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect values");
            }
        }
    }
}
