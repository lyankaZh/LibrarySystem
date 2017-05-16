using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library
{
    public partial class AddNewGenreWindow: Window
    {
        readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private CreatingBookViewModel viewModel;


        public AddNewGenreWindow(CreatingBookViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
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
                    viewModel.Genres = new ObservableCollection<Genre>(_unitOfWork.GenreRepository.Get().ToList());
                    Close();
                }
                else
                {
                    MessageBox.Show("Такий жанр уже існує!");
                }
            }
            else
            {
                MessageBox.Show("Неможливо додати порожній жанр!");
            }
        }
    }
}
