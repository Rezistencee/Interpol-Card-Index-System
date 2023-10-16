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
using System.Windows;
using System.Windows.Input;

namespace Interpol_Card_Index_System.ViewModel
{
    public class CriminalGroupsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CriminalGroup> CriminalGroups
        {
            get { return RepositoryService.Instance.CriminalGroups; }
        }

        public ICommand AddCrimeGroup { get; private set; }
        public ICommand ViewDetailsCommand { get; private set; }

        public CriminalGroupsViewModel()
        {
            AddCrimeGroup = new RelayCommand(AddCriminalGroup);
            ViewDetailsCommand = new RelayCommand(ViewDetails);
        }

        private void ViewDetails(object parameter)
        {
            if(parameter is CriminalGroup criminalGroup)
            {
                MessageBox.Show(criminalGroup.ID.ToString());
            }
        }

        private void AddCriminalGroup(object parameter)
        {
            CriminalGroup newCriminalGroup = new CriminalGroup("Bloods", "Shug Nite", new List<string>() { "Killers", "Drugs" }, new List<string>() { "USA", "Spain" });

            RepositoryService.Instance.AddCriminalGroup(newCriminalGroup);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
