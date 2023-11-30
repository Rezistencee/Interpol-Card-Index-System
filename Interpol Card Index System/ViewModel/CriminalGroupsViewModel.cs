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
    public class CriminalGroupsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CollectionFilter<CriminalGroup> _filteredCriminalGroups;
        private string _groupNameFilterText;

        public ObservableCollection<CriminalGroup> CriminalGroups
        {
            get { return RepositoryService.Instance.CriminalGroups; }
        }

        public CollectionFilter<CriminalGroup> FilteredCriminalGroups
        {
            get => _filteredCriminalGroups;
            set
            {
                _filteredCriminalGroups = value;
                OnPropertyChanged(nameof(FilteredCriminalGroups));
            }
        }

        public string GroupNameFilterText
        {
            get => _groupNameFilterText;
            set
            {
                _groupNameFilterText = value;
                OnPropertyChanged(nameof(GroupNameFilterText));
                FilterCommand.Execute(null);
            }
        }

        public ICommand AddCrimeGroup { get; private set; }
        public ICommand ViewDetailsCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }

        public CriminalGroupsViewModel()
        {
            _filteredCriminalGroups = new CollectionFilter<CriminalGroup>(CriminalGroups);

            AddCrimeGroup = new RelayCommand(AddCriminalGroup);
            ViewDetailsCommand = new RelayCommand(ViewDetails);
            FilterCommand = new RelayCommand(Filter);
        }

        private void ViewDetails(object parameter)
        {
            if(parameter is CriminalGroup criminalGroup)
            {
                CriminalGroup_Information criminalGroupView = new CriminalGroup_Information(criminalGroup);

                criminalGroupView.Show();
            }
        }

        private void AddCriminalGroup(object parameter)
        {
            AddNewCriminalGroupViewModel targetView = new AddNewCriminalGroupViewModel();
            AddNewCriminalGroup addNewCriminalGroupWindow = new AddNewCriminalGroup();
            addNewCriminalGroupWindow.DataContext = targetView;

            addNewCriminalGroupWindow.ShowDialog();

            if (targetView.IsResult)
                RepositoryService.Instance.AddCriminalGroup(targetView.NewCriminalGroup);
        }

        private void Filter(object parameter)
        {
            _filteredCriminalGroups.AddFilter(criminalGroup => criminalGroup.Name.Contains(GroupNameFilterText));

            OnPropertyChanged(nameof(GroupNameFilterText));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
