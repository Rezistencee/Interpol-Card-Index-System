using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Models
{
    public class Criminal
    {
        private static int _id = 1;

        public int ID { get; private set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string SpecialCharacteristics { get; set; }
        public string CrimeDescription { get; set; }
        public string PhotoPath { get; set; }

        public Criminal()
        {
            ID = _id++;
        }
    }
}
