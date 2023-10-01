using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Interpol_Card_Index_System.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<User> _users;

        private string _username;
        public string Username
        {
            get 
            { 
                return _username; 
            }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get 
            { 
                return _password; 
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginCommand { get; private set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);

            _users = new List<User>
            {
                new User() {Name = "Alex Winchester", Login = "Test123", Password = "qwerty123", AccessLevel = 'A'},
                new User() {Name = "Sam Winchester", Login = "Test2546", Password = "qwerty1234", AccessLevel = 'A'}
            };
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login(object parameter)
        {
            User user = YourDataAccessMethodToGetUser(Username, Password);

            if (user != null)
            {
                MessageBox.Show($"You authorized in system as a {user.Name}!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private User YourDataAccessMethodToGetUser(string username, string password)
        {
            return _users.Find(u => u.Login == username && u.Password == password);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
