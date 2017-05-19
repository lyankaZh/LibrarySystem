using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewAuthorWindow : Window
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        private CreatingBookViewModel viewModel;

        public AddNewAuthorWindow( CreatingBookViewModel model)
        {
            InitializeComponent();
            viewModel = model;
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
                unitOfWork.AuthorRepository.Insert(author);
                unitOfWork.Save();

                viewModel.Authors = new ObservableCollection<Author>(unitOfWork.AuthorRepository.Get().ToList());
                Close();
            }
            else
            {
                MessageBox.Show("Вкажіть ім'я та прізвище автора");
            }
        }
    }
}
