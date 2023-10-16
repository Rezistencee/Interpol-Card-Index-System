using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Navigation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Interpol_Card_Index_System.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DispatcherTimer _timer;

        public RelayCommand LogoutCommand { get; private set; }
        public RelayCommand ShowCriminalGroupWindow { get; private set; }
        public RelayCommand ShowCriminalWindow { get; private set; }

        public MainWindowViewModel()
        {
            LogoutCommand = new RelayCommand(Logout, IsUserAuthorized);
            ShowCriminalGroupWindow = new RelayCommand(CrimeWindowOpen, IsUserAuthorized);
            ShowCriminalWindow = new RelayCommand(CriminalWindowOpen, IsUserAuthorized);

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private string _currentDateAndTime;
        public string CurrentDateAndTime
        {
            get
            {
                return _currentDateAndTime;
            }
            set
            {
                _currentDateAndTime = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUserName => SessionService.Instance.CurrentUser.Name;
        public char CurrentUserAccess => SessionService.Instance.CurrentUser.AccessLevel;

        public int CriminalsCount => RepositoryService.Instance.Criminals.Count;
        public int CriminalGroupsCount => RepositoryService.Instance.CriminalGroups.Count;

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentDateTime();
        }

        private void UpdateCurrentDateTime()
        {
            CurrentDateAndTime = DateTime.Now.ToString();
        }

        private void CrimeWindowOpen(object parameter)
        {
            Views.CriminalGroupsWindow criminalGroupsWindow = new Views.CriminalGroupsWindow();
            criminalGroupsWindow.Show();
        }

        private void CriminalWindowOpen(object parameter)
        {
            Views.CriminalWindow criminalWindow = new Views.CriminalWindow();
            criminalWindow.Show();
        }

        private void Logout(object parameter)
        {
            SessionService.Instance.ResetSession();
            Views.LoginWindow loginWindow = new Views.LoginWindow();
            Application.Current.MainWindow.Close();

            loginWindow.Show();
        }

        private bool IsUserAuthorized()
        {
            return SessionService.Instance.CurrentUser != null ? true : false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
