using System.Collections.Generic;
using DatabaseEntities.Interfaces;

namespace DataCache
{
    public interface IItemData<T> where T : IObject
    {
        void DataHasChanged();
        bool HasNewData();
        IEnumerable<T> GetAllItems();
        void SetNewItems(IEnumerable<T> items);
        T GetItemByID(int id);
    }

}
