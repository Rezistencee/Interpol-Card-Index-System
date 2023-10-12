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
    public class CriminalWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Criminal> Criminals
        {
            get { return RepositoryService.Instance.Criminals; }
        }

        public ICommand AddCriminalCommand { get; private set; }

        public CriminalWindowViewModel()
        {
            AddCriminalCommand = new RelayCommand(AddCriminal);
        }

        private void AddCriminal(object parameter)
        {
            Criminal newCriminal = new Criminal();

            RepositoryService.Instance.AddCriminal(newCriminal);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
