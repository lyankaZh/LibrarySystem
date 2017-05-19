using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewGenreWindow: Window
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly CreatingBookViewModel _creatingBookView;

        public AddNewGenreWindow(CreatingBookViewModel viewModel, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _creatingBookView = viewModel;
            _unitOfWork = unitOfWork;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(genreTextBox.Text))
            {
                var genre = _unitOfWork.GenreRepository
                    .Get()
                    .FirstOrDefault(x => x.GenreName == genreTextBox.Text);
                if (genre == null)
                {
                    _unitOfWork.GenreRepository.Insert(
                        new Genre
                    {
                       GenreName = genreTextBox.Text
                    });
                       
                    _unitOfWork.Save();
                    _creatingBookView.Genres = new ObservableCollection<Genre>(_unitOfWork.GenreRepository.Get().ToList());
                    Close();
                }
                else
                {
                    MessageBox.Show("Such genre already exists!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect genre");
            }
        }
    }
}
