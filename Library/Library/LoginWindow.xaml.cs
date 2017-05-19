using System.Windows;
using Domain;
using Domain.Repository;

namespace Library
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var login = loginTextBox.Text;
            var pass = passwordBox.Password;

            var user = unitOfWork.UserRepository.GetById(login);
            if (user != null && user.Password == Encryptor.Encrypt(pass))
            {
                var window = new MainWindow();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }
    }
}
