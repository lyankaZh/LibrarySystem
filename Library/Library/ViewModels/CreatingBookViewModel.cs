using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Domain.Models;
using Domain.Repository;

namespace Library.ViewModels
{
    public class CreatingBookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Genre> genres;
        private ObservableCollection<Author> authors;
        private ObservableCollection<Language> languages;
        private ObservableCollection<Publisher> publishers;
        UnitOfWork unitOfWork;

        public CreatingBookViewModel(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            genres = new ObservableCollection<Genre>(unitOfWork.GenreRepository.Get());
            languages = new ObservableCollection<Language>(unitOfWork.LanguageRepository.Get());
            authors = new ObservableCollection<Author>(unitOfWork.AuthorRepository.Get());
            publishers = new ObservableCollection<Publisher>(unitOfWork.PublisherRepository.Get());
        }

        public ObservableCollection<Genre> Genres
        {
            get { return genres; }
            set
            {
                if (value != genres)
                {
                    genres = value;
                    NotifyPropertyChanged("Genres");
                }
            }
        }
        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set
            {
                if (value != languages)
                {
                    languages = value;
                    NotifyPropertyChanged("Languages");
                }
            }
        }
        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set
            {
                if (value != authors)
                {
                    authors = value;
                    NotifyPropertyChanged("Authors");
                }
            }
        }
        public ObservableCollection<Publisher> Publishers
        {
            get { return publishers; }
            set
            {
                if (value != publishers)
                {
                    publishers = value;
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
