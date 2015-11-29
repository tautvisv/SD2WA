using DatabaseEntities.Entities;
using DataRepo;
using DataRepositoriesInterfaces;

namespace DataRepositories.Repositories
{
    public class ItemRepository : GenericRepositoryBase<Item>,  IItemRepository
    {
        public ItemRepository(Dota2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
