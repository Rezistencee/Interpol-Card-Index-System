using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Models
{
    public class CriminalGroup
    {
        private static int _nextId = 1;

        #region Property
        public int ID { get; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public List<string> Activities { get; set; }
        public List<string> Countries { get; set; }
        #endregion

        public CriminalGroup(string name, string leader, List<string> activities, List<string> countries)
        {
            ID = _nextId++;
            Name = name;
            Leader = leader;
            Activities = activities;
            Countries = countries;
        }
    }
}
