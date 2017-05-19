using System.Collections.ObjectModel;
using System.ComponentModel;
using Domain.Models;
using Domain.Repository;

namespace Library.ViewModels
{
    public class BorrowInfoDisplayViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<BorrowInfo> _borrowInfo;

        public BorrowInfoDisplayViewModel(IUnitOfWork unit)
        {
            var unitOfWork = unit;
            _borrowInfo = new ObservableCollection<BorrowInfo>(unitOfWork.BorrowInfoRepository.Get());
        }

        public ObservableCollection<BorrowInfo> BorrowInfo
        {
            get { return _borrowInfo; }
            set
            {
                if (value != _borrowInfo)
                {
                    _borrowInfo = value;
                    NotifyPropertyChanged("BorrowInfo");
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
