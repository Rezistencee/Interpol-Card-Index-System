using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Services.Interfaces
{
    public interface ICollectionFilter<T>
    {
        void AddFilter(Func<T, bool> predicate);
        void RemoveFilter(Func<T, bool> predicate);
    }
}
