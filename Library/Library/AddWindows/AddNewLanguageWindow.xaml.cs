using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library
{
    public partial class AddNewLanguageWindow: Window
    {
        private readonly IUnitOfWork _unitOfWork;
        private CreatingBookViewModel viewModel;
        public AddNewLanguageWindow( CreatingBookViewModel model, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            viewModel = model;
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
                    viewModel.Languages = new ObservableCollection<Language>(_unitOfWork.LanguageRepository.Get().ToList()); 
                    Close();
                }
                else
                {
                    MessageBox.Show("Така мова уже існує!");
                }
            }
            else
            {
                MessageBox.Show("Неможливо додати порожню мову!");
            }
        }
    }
}
