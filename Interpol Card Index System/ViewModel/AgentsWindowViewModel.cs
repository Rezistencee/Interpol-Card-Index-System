using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Models;
using Interpol_Card_Index_System.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interpol_Card_Index_System.ViewModel
{
    internal class AgentsWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CollectionFilter<User> _flteredUsers;
        private string _nameFilterText;

        public ObservableCollection<User> Users
        {
            get { return RepositoryService.Instance.Users; }
        }

        public CollectionFilter<User> FilteredUsers
        {
            get => _flteredUsers;
            set
            {
                _flteredUsers = value;
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }

        public string NameFilterText
        {
            get => _nameFilterText;
            set
            {
                _nameFilterText = value;
                OnPropertyChanged(nameof(NameFilterText));
                FilterCommand.Execute(null);
            }
        }

        public ICommand FilterCommand { get; private set; }

        public AgentsWindowViewModel()
        {
            _flteredUsers = new CollectionFilter<User>(Users);

            FilterCommand = new RelayCommand(Filter);
        }

        private void Filter(object parameter)
        {
            _flteredUsers.AddFilter(criminal => criminal.Name.Contains(NameFilterText));

            OnPropertyChanged(nameof(NameFilterText));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
