using Interpol_Card_Index_System.Commands;
using Interpol_Card_Index_System.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Interpol_Card_Index_System.ViewModel
{
    public class AddNewCriminalViewModel : INotifyPropertyChanged
    {
        private Criminal _newCriminal;
        private string _selectedGender;
        private DateTime _birthday;
        private bool _isResult;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Criminal NewCriminal
        {
            get { return _newCriminal; }
            set
            {
                _newCriminal = value;
                OnPropertyChanged(nameof(NewCriminal));
            }
        }

        public DateTime SelectedBirthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(SelectedBirthday));
            }
        }

        public string SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }

        public bool IsResult
        {
            get => _isResult;
        }

        public ICommand ConfirmCommand { get; private set; }
        public ICommand OpenImageCommand { get; private set; }

        public AddNewCriminalViewModel()
        {
            SelectedBirthday = DateTime.Now;
            _isResult = false;

            NewCriminal = new Criminal();
            ConfirmCommand = new RelayCommand(Confirm);
            OpenImageCommand = new RelayCommand(OpenImage);
        }

        private void Confirm(object parameter)
        {
            if (IsModelValid(NewCriminal))
            {
                NewCriminal.Gender = SelectedGender;
                NewCriminal.AccessLevel = 'D';
                _isResult = true;
            }
            else
            {
                MessageBox.Show("Not all data is valid!");
            }
        }

        private void OpenImage(object obj)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(imagePath);

                Guid uniqueFileID = Guid.NewGuid();
                string targetPath = Path.Combine(Environment.CurrentDirectory, "Criminal_Images/", uniqueFileID.ToString() + fileExtension);
                File.Copy(imagePath, targetPath, true);

                NewCriminal.PhotoPath = targetPath;
            }
        }

        private void CloseWindow(Window window)
        {
            window?.Close();
        }

        private bool IsModelValid(Criminal criminal)
        {
            var properties = typeof(Criminal).GetProperties();

            foreach (var property in properties)
            {
                var columnName = property.Name;
                var validationResult = criminal[columnName];

                if (!string.IsNullOrEmpty(validationResult))
                {
                    return false;
                }
            }
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
