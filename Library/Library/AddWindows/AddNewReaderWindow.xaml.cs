using System.Collections.ObjectModel;
using System.Windows;
using Domain.Models;
using Domain.Repository;
using Library.ViewModels;

namespace Library.AddWindows
{
    public partial class AddNewReaderWindow : Window
    {
        private IUnitOfWork _unitOfWork;
        private readonly ReadersDisplayViewModel _readersDisplayViewModel;
        private int _editedReaderId;
        private OperationType _operationType;

        public AddNewReaderWindow(IUnitOfWork unitOfWork, ReadersDisplayViewModel readersDisplayViewModel)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _readersDisplayViewModel = readersDisplayViewModel;
            _operationType = OperationType.Create;
        }


        public AddNewReaderWindow(IUnitOfWork unitOfWork, ReadersDisplayViewModel readersDisplayViewModel, Reader reader)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _readersDisplayViewModel = readersDisplayViewModel;
            _operationType = OperationType.Edit;
            _editedReaderId = reader.ReaderId;
            SetInitialTextOnTextBoxes(reader);
        }

        private void SetInitialTextOnTextBoxes(Reader reader)
        {
            lastNameTextBox.Text = reader.LastName;
            firstNameTextBox.Text = reader.FirstName;
            middleNameTextBox.Text = reader.MiddleName;
            phoneNumberTextBox.Text = reader.PhoneNumber;
            addressTextBox.Text = reader.Address;
            datePicker.SelectedDate = reader.RegistrationDate;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (AreTextFieldsValid())
                {
                    var reader = new Reader
                    {
                        ReaderId = _editedReaderId,
                        LastName = lastNameTextBox.Text,
                        MiddleName = middleNameTextBox.Text,
                        FirstName = firstNameTextBox.Text,
                        PhoneNumber = phoneNumberTextBox.Text,
                        Address = addressTextBox.Text,
                        RegistrationDate = datePicker.SelectedDate
                    };
                   
                    if (_operationType == OperationType.Create)
                    {
                        CreateReader(reader);
                    }
                    else if (_operationType == OperationType.Edit)
                    {
                        EditReader(reader);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Check your values");
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Smth went wrong. Try again");
            //}
        }

        public void CreateReader(Reader reader)
        {
            _unitOfWork.ReaderRepository.Insert(reader);
            _unitOfWork.Save();
            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(_unitOfWork.ReaderRepository.Get());
        }

        public void EditReader(Reader newReader)
        {
            var editedReader = _unitOfWork.ReaderRepository.GetById(_editedReaderId);
            if (editedReader != null)
            {
                editedReader.FirstName = newReader.FirstName;
                editedReader.LastName = newReader.LastName;
                editedReader.MiddleName = newReader.MiddleName;
                editedReader.PhoneNumber
                    = newReader.PhoneNumber;
                editedReader.Address = newReader.Address;
                editedReader.RegistrationDate = newReader.RegistrationDate;

            }
            _unitOfWork.ReaderRepository.Update(editedReader);
            _unitOfWork.Save();
            _readersDisplayViewModel.Readers = new ObservableCollection<Reader>(_unitOfWork.ReaderRepository.Get());
        }

        private bool AreTextFieldsValid()
        {
            if (string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(middleNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(phoneNumberTextBox.Text))
            {
                return false;
            }
            if (datePicker.SelectedDate == null)
            {
                return false;
            }

            return true;
        }
    }
}
