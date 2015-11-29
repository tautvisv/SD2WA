using System.Collections.Generic;
using System.Linq;
using DatabaseEntities.Interfaces;

namespace DataCache
{
    public class ItemData<T> : IItemData<T> where T : IObject
    {
        private bool _isRefreshed;
        private IEnumerable<T> _items;

        public ItemData()
        {
            _isRefreshed = false;
        }

        public void DataHasChanged()
        {
            _isRefreshed = false;
        }

        public bool HasNewData()
        {
            return _isRefreshed;
        }

        public IEnumerable<T> GetAllItems()
        {
            return _items;
        }

        public void SetNewItems(IEnumerable<T> items)
        {
            _items = items;
            _isRefreshed = true;
        }

        public T GetItemByID(int id)
        {
            return _items.FirstOrDefault(x => x.ID == id);
        }
    }
}
