using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewLanguageWindow
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreatingBookViewModel _viewModel;
        public AddNewLanguageWindow( CreatingBookViewModel model, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _viewModel = model;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(languageTextBox.Text))
            {
                var language = _unitOfWork.LanguageRepository
                    .Get()
                    .FirstOrDefault(x => x.LanguageName == languageTextBox.Text);
                if (language == null)
                {
                    _unitOfWork.LanguageRepository.Insert(
                        new Language {LanguageName = languageTextBox.Text});
                    _unitOfWork.Save();
                    _viewModel.Languages = new ObservableCollection<Language>(_unitOfWork.LanguageRepository.Get().ToList()); 
                    Close();
                }
                else
                {
                    MessageBox.Show("Such language already exists!");
                }
            }
            else
            {
                MessageBox.Show("Can`t add empty language!");
            }
        }
    }
}
