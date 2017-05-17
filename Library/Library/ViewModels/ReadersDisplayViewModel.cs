using System.Collections.ObjectModel;
using System.ComponentModel;
using Domain.Models;
using Domain.Repository;

namespace Library.ViewModels
{
    public class ReadersDisplayViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Reader> _readers;

        public ReadersDisplayViewModel(IUnitOfWork unit)
        {
            var unitOfWork = unit;
            _readers = new ObservableCollection<Reader>(unitOfWork.ReaderRepository.Get());
        }

        public ObservableCollection<Reader> Readers
        {
            get { return _readers; }
            set
            {
                if (value != _readers)
                {
                    _readers = value;
                    NotifyPropertyChanged("Readers");
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
