using Interpol_Card_Index_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Interpol_Card_Index_System.Services
{
    public class RepositoryService
    {
        private static RepositoryService _instance;
        public static RepositoryService Instance => _instance ??= new RepositoryService();

        private ObservableCollection<User> _usersList;
        private ObservableCollection<Criminal> _criminalsList;
        private ObservableCollection<CriminalGroup> _crimeGroups;

        public ObservableCollection<User> Users
        {
            get
            {
                return _usersList;
            }
        }

        public ObservableCollection<Criminal> Criminals
        {
            get
            {
                return _criminalsList;
            }
        }

        public ObservableCollection<CriminalGroup> CriminalGroups
        {
            get
            {
                return _crimeGroups;
            }
        }

        private RepositoryService() {
            _usersList = new ObservableCollection<User>()
            {
                new User() {Name = "Alex Winchester", Login = "Test123", Password = "qwerty123", AccessLevel = 'B'},
                new User() {Name = "Sam Winchester", Login = "Test2546", Password = "qwerty1234", AccessLevel = 'A'}
            };

            _crimeGroups = new ObservableCollection<CriminalGroup>()
            {
                new CriminalGroup("Sierra", "El Gato", new List<string>() {"Killers", "Drugs"}, new List<string>() {"USA", "Spain" }, "Lorem ipsum...")
            };

            _criminalsList = new ObservableCollection<Criminal>
            {
                new Criminal() {FullName = "Jack Sparrow", Alias = "Sparrow", DateOfBirth = DateTime.Parse("12.10.1982"), Nationality = "Ukrainian", Weight = 96, AccessLevel = 'B', PhotoPath = "/Views/girl.jpg"},
                new Criminal() {FullName = "Ryan Gosling", Alias = "Sierra-6", DateOfBirth = DateTime.Parse("24.07.1994"), Nationality = "USA", Weight = 84, AccessLevel = 'A', PhotoPath = Path.Combine(Environment.CurrentDirectory, "Criminal_Photos", "sierra.jpg")}
            };
        }

        public void AddUser(User userInstance)
        {
            _usersList.Add(userInstance);
        }

        public void AddCriminal(Criminal criminalInstance)
        {
            _criminalsList.Add(criminalInstance);
        }

        public void AddCriminalGroup(CriminalGroup criminalGroupInstance)
        {
            _crimeGroups.Add(criminalGroupInstance);
        } 
    }
}
