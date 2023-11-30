using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Models
{
    public class Criminal : IDataErrorInfo
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
        public char AccessLevel { get; set; }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case nameof(FullName):
                        {
                            if (string.IsNullOrWhiteSpace(FullName))
                                result = "Full Name is required.";

                            if (FullName.Length < 8 || FullName.Length > 128)
                                result = "Full Name length must be more than 8 symbols or less than 128 symbols.";
                            break;
                        }
                    case nameof(Alias):
                        {
                            if (string.IsNullOrWhiteSpace(Alias))
                                result = "Alias is required.";

                            if (Alias.Length < 2 || Alias.Length > 32)
                                result = "Full Name length must be more than 2 symbols or less than 32 symbols.";
                            break;
                        }
                    case nameof(Nationality):
                        {
                            if (string.IsNullOrWhiteSpace(Nationality))
                                result = "Nationality is required.";
                            break;
                        }
                }
                return result;
            }
        }

        public string Error => null;

        public Criminal()
        {
            ID = _id++;
            FullName = String.Empty;
            Alias = String.Empty;
            PhotoPath = String.Empty;
            DateOfBirth = DateTime.Now;
        }
    }
}
