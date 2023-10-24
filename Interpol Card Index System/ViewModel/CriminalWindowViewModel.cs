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

        public ObservableCollection<Criminal> Criminals
        {
            get { return RepositoryService.Instance.Criminals; }
        }

        public ICommand AddCriminalCommand { get; private set; }
        public ICommand ViewDetailsCommand { get; private set; }

        public CriminalWindowViewModel()
        {
            AddCriminalCommand = new RelayCommand(AddCriminal);
            ViewDetailsCommand = new RelayCommand(ViewDetails);
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
            Criminal newCriminal = new Criminal();

            RepositoryService.Instance.AddCriminal(newCriminal);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
