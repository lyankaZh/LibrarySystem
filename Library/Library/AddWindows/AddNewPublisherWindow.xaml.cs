using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewPublisherWindow
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly CreatingBookViewModel _viewModel;

        public AddNewPublisherWindow(CreatingBookViewModel model, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _viewModel = model;
            _unitOfWork = unitOfWork;
        }

        private void cancelButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(publisherNameTextBox.Text) &&
                !string.IsNullOrEmpty(cityTextBox.Text) &&
                !string.IsNullOrEmpty(countryTextBox.Text))
            {
                var publisher = _unitOfWork.PublisherRepository
                    .Get()
                    .FirstOrDefault(x => x.PublisherName == publisherNameTextBox.Text && 
                    x.City == cityTextBox.Text && x.Country == countryTextBox.Text);
                if (publisher == null)
                {
                    _unitOfWork.PublisherRepository.Insert(
                        new Publisher
                        {
                            PublisherName = publisherNameTextBox.Text,
                            City = cityTextBox.Text,
                            Country = countryTextBox.Text
                        }
                       );

                    _unitOfWork.Save();
                    _viewModel.Publishers = new ObservableCollection<Publisher>(_unitOfWork.PublisherRepository.Get().ToList());
                    Close();
                }
                else
                {
                    MessageBox.Show("Publisher already exists");
                }
            }
            else
            {
                MessageBox.Show("Incorrect values!");
            }
        }
    }
}
