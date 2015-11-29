using DatabaseEntities.Entities;

namespace DataCache
{
    public interface ICacheSingleton
    {
        IItemData<Hero> Heroes { get; }
        IItemData<Item> Items { get; }
    }

    public sealed class CacheSingleton : ICacheSingleton
    {
        private static CacheSingleton _instance;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        public readonly IItemData<Hero> _heroes;
        public readonly IItemData<Item> _items;
        public IItemData<Hero> Heroes { get { return _heroes; } }
        public IItemData<Item> Items { get { return _items; } }

        private CacheSingleton()
        {
            _heroes = new ItemData<Hero>();
            _items = new ItemData<Item>();
        }

        public static CacheSingleton Instance
        {
            get { return _instance ?? (_instance = new CacheSingleton()); }
        }
    }
}
