using System.Collections.ObjectModel;
using System.ComponentModel;
using Domain.Repository;
using Library.Helpers;

namespace Library.ViewModels
{
    public class BooksDisplayViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<BookModel> _books;

        public BooksDisplayViewModel(IUnitOfWork unit)
        {
            var unitOfWork = unit;
            _books = new ObservableCollection<BookModel>(unitOfWork.BookRepository.Get().ToBookModelsList(unitOfWork));
        }

        public ObservableCollection<BookModel> Books
        {
            get { return _books; }
            set
            {
                if (value != _books)
                {
                    _books = value;
                    NotifyPropertyChanged("Books");
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
