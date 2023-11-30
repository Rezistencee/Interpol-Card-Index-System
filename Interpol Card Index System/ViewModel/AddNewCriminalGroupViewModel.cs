using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interpol_Card_Index_System.ViewModel
{
    public class AddNewCriminalGroupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _allCountries;
        private ObservableCollection<string> _allActivities;
        private ObservableCollection<string> _selectedActivities;
        private ObservableCollection<string> _selectedCountries;
        private CriminalGroup _newCriminalGroup;
        private bool _isResult;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CriminalGroup NewCriminalGroup
        {
            get { return _newCriminalGroup; }
            set
            {
                _newCriminalGroup = value;
                OnPropertyChanged(nameof(NewCriminalGroup));
            }
        }
        public ObservableCollection<string> AllActivities
        {
            get { return _allActivities; }
            set
            {
                _allActivities = value;
                OnPropertyChanged(nameof(AllActivities));
            }
        }

        public ObservableCollection<string> AllCountries
        {
            get { return _allCountries; }
            set
            {
                _allCountries = value;
                OnPropertyChanged(nameof(AllCountries));
            }
        }

        public ObservableCollection<string> SelectedActivities
        {
            get { return _selectedActivities; }
            set 
            { 
                _selectedActivities = value;
                OnPropertyChanged(nameof(SelectedActivities));
            }
        }

        public ObservableCollection<string> SelectedCountries
        {
            get { return _selectedCountries; }
            set
            {
                _selectedCountries = value;
                OnPropertyChanged(nameof(SelectedCountries));
            }
        }

        public bool IsResult
        {
            get => _isResult;
        }

        public ICommand ConfirmCommand { get; private set; }
        public ICommand SelectionActivitiesChangedCommand { get; private set; }
        public ICommand SelectionCountriesChangedCommand { get; private set; }

        public AddNewCriminalGroupViewModel()
        {
            _newCriminalGroup = new CriminalGroup();
            _allActivities = new ObservableCollection<string>();
            _allCountries = LoadCountriesFromFile(Path.Combine(Environment.CurrentDirectory, "countries.txt"));
            _isResult = false;

            _selectedActivities = new ObservableCollection<string>();
            _selectedCountries = new ObservableCollection<string>();

            _allActivities.Add("Theft");
            _allActivities.Add("Drug-related crimes");
            _allActivities.Add("Financial crimes");
            _allActivities.Add("Cybercrimes");
            _allActivities.Add("Terrorism");

            SelectionActivitiesChangedCommand = new RelayCommand(OnSelectionChanged);
            SelectionCountriesChangedCommand = new RelayCommand(OnSelectionCountriesChanged);
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm(object parameter)
        {
            NewCriminalGroup.Activities = SelectedActivities.ToList();
            NewCriminalGroup.Countries = SelectedCountries.ToList();
            _isResult = true;
        }

        private ObservableCollection<string> LoadCountriesFromFile(string filePath)
        {
            ObservableCollection<string> countries = new ObservableCollection<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        countries.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return countries;
        }

        private void OnSelectionChanged(object selectedItems)
        {
            if (selectedItems is IList items)
            {
                SelectedActivities.Clear();

                foreach (var item in items)
                {
                    if (item is string str)
                    {
                        SelectedActivities.Add(str);
                    }
                }
            }
        }

        private void OnSelectionCountriesChanged(object selectedItems)
        {
            if (selectedItems is IList items)
            {
                SelectedCountries.Clear();

                foreach (var item in items)
                {
                    if (item is string str)
                    {
                        SelectedCountries.Add(str);
                    }
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
