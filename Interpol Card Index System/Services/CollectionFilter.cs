using Interpol_Card_Index_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol_Card_Index_System.Services
{
    public class CollectionFilter<T> : ObservableCollection<T>, ICollectionFilter<T>
    {
        private ObservableCollection<T> _originalCollection;
        private List<Func<T, bool>> _filters;

        public CollectionFilter(ObservableCollection<T> collection)
        {
            _originalCollection = collection;
            _filters = new List<Func<T, bool>>();

            UpdateItems(_originalCollection);
        }

        public void AddFilter(Func<T, bool> predicate)
        {
            _filters.Add(predicate);
            ApplyFilters();
        }

        public void RemoveFilter(Func<T, bool> predicate)
        {
            _filters.Remove(predicate);
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            Clear();

            foreach (var item in _originalCollection.Where(item => _filters.All(filter => filter(item))))
            {
                Add(item);
            }
        }

        private void UpdateItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
