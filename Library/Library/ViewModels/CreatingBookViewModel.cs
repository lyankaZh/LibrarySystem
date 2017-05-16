using System.Collections.ObjectModel;
using System.ComponentModel;
using Domain.Models;
using Domain.Repository;

namespace Library.ViewModels
{
    public class CreatingBookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Genre> _genres;
        private ObservableCollection<Author> _authors;
        private ObservableCollection<Language> _languages;
        private ObservableCollection<Publisher> _publishers;
        

        public CreatingBookViewModel(IUnitOfWork unit)
        {
            var unitOfWork = unit;
            _genres = new ObservableCollection<Genre>(unitOfWork.GenreRepository.Get());
            _languages = new ObservableCollection<Language>(unitOfWork.LanguageRepository.Get());
            _authors = new ObservableCollection<Author>(unitOfWork.AuthorRepository.Get());
            _publishers = new ObservableCollection<Publisher>(unitOfWork.PublisherRepository.Get());
        }

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                if (value != _genres)
                {
                    _genres = value;
                    NotifyPropertyChanged("Genres");
                }
            }
        }
        public ObservableCollection<Language> Languages
        {
            get { return _languages; }
            set
            {
                if (value != _languages)
                {
                    _languages = value;
                    NotifyPropertyChanged("Languages");
                }
            }
        }

        public ObservableCollection<Author> Authors
        {
            get { return _authors; }
            set
            {
                if (value != _authors)
                {
                    _authors = value;
                    NotifyPropertyChanged("Authors");
                }
            }
        }

        public ObservableCollection<Publisher> Publishers
        {
            get { return _publishers; }
            set
            {
                if (value != _publishers)
                {
                    _publishers = value;
                    NotifyPropertyChanged("Publishers");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
