using System.Collections.Generic;
using DatabaseEntities.Entities;
using DataCache;
using DataRepositoriesInterfaces;

namespace DataServices.Services
{
    public class MiscService : IMiscService
    {
        protected readonly IHeroRepository HeroesRepository;
        protected readonly IItemRepository ItemsRepository;
        private readonly ICacheSingleton _cache;

        public MiscService(IHeroRepository heroesRepository, IItemRepository itemsRepository, ICacheSingleton cachedData)
        {
            HeroesRepository = heroesRepository;
            ItemsRepository = itemsRepository;
            _cache = cachedData;
        }

        public Hero GetHeroByID(int id)
        {
            if (!_cache.Heroes.HasNewData())
            {
                _cache.Heroes.SetNewItems(HeroesRepository.List);
            }
            return _cache.Heroes.GetItemByID(id);
            //return HeroesRepository.GetById(id);
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            if (!_cache.Heroes.HasNewData())
            {
                _cache.Heroes.SetNewItems(HeroesRepository.List);
            }
            return _cache.Heroes.GetAllItems();
            //return HeroesRepository.List;
        }
        public IEnumerable<Item> GetAllItems()
        {
            if (!_cache.Items.HasNewData())
            {
                _cache.Items.SetNewItems(ItemsRepository.List);
            }
            return _cache.Items.GetAllItems();
            //return ItemsRepository.List;
        }

        public Hero GetHero(int id)
        {
            if (!_cache.Heroes.HasNewData())
            {
                _cache.Heroes.SetNewItems(HeroesRepository.List);
            }
            return _cache.Heroes.GetItemByID(id);
        }
    }
}
