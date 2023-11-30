using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Models;
using Interpol_Card_Index_System.Services;
using Interpol_Card_Index_System.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Interpol_Card_Index_System.ViewModel
{
    public class CriminalWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CollectionFilter<Criminal> _filteredCriminals;
        private string _nameFilterText;

        public ObservableCollection<Criminal> Criminals
        {
            get { return RepositoryService.Instance.Criminals; }
        }

        public CollectionFilter<Criminal> FilteredCriminals
        {
            get => _filteredCriminals;
            set
            {
                _filteredCriminals = value;
                OnPropertyChanged(nameof(FilteredCriminals));
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

        public ICommand AddCriminalCommand { get; private set; }
        public ICommand ViewDetailsCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }

        public CriminalWindowViewModel()
        {
            _filteredCriminals = new CollectionFilter<Criminal>(Criminals);

            AddCriminalCommand = new RelayCommand(AddCriminal);
            ViewDetailsCommand = new RelayCommand(ViewDetails);

            FilterCommand = new RelayCommand(Filter);
        }

        private void ViewDetails(object parameter)
        {
            if (parameter is Criminal criminal)
            {
                if (SessionService.Instance.CurrentUser.AccessLevel > criminal.AccessLevel)
                {
                    MessageBox.Show("You can't get access to this information!");
                    return;
                }

                Criminal_Information criminal_InfoWindow = new Criminal_Information(criminal);
                
                criminal_InfoWindow.Show();
            }
        }

        private void AddCriminal(object parameter)
        {
            AddNewCriminal addNewCriminalWindow = new AddNewCriminal();
            
            addNewCriminalWindow.Show();
        }

        private void Filter(object parameter)
        {
            _filteredCriminals.AddFilter(criminal => criminal.FullName.Contains(NameFilterText));

            OnPropertyChanged(nameof(NameFilterText));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
