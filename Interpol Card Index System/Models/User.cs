using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public char AccessLevel { get; set; }

        public User()
        {
            Name = String.Empty;
            Login = String.Empty;
            Password = String.Empty;
            AccessLevel = 'D';
        }
    }
}
