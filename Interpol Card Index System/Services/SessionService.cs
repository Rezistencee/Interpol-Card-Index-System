using Interpol_Card_Index_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Services
{
    public class SessionService
    {
        private static SessionService _instance;
        public static SessionService Instance => _instance ??= new SessionService();

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value;
        }

        private SessionService() { }

        public void ResetSession()
        {
            _currentUser = null;
        }
    }
}
