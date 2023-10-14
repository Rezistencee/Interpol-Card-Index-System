using Interpol_Card_Index_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Services
{
    public class RepositoryService
    {
        private static RepositoryService _instance;
        public static RepositoryService Instance => _instance ??= new RepositoryService();

        private ObservableCollection<User> _usersList;
        private ObservableCollection<Criminal> _criminalsList;

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

        private RepositoryService() {
            _usersList = new ObservableCollection<User>()
            {
                new User() {Name = "Alex Winchester", Login = "Test123", Password = "qwerty123", AccessLevel = 'A'},
                new User() {Name = "Sam Winchester", Login = "Test2546", Password = "qwerty1234", AccessLevel = 'A'}
            };

            _criminalsList = new ObservableCollection<Criminal>
            {
                new Criminal() {FullName = "Jack Sparrow", Alias = "Sparrow", DateOfBirth = DateTime.Parse("12.10.1982"), Nationality = "Ukrainian"},
                new Criminal() {FullName = "Ryan Gosling", Alias = "Sierra-6", DateOfBirth = DateTime.Parse("24.07.1994"), Nationality = "USA"}
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
    }
}
