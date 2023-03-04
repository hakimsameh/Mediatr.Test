using MediatrTest.Domain.Repositories;

namespace MediatrTest.Infrastructure.Repositories;

internal class ItemRepository : RepositoryBase<ItemModel, Guid>, IItemModelRepository
{
    public ItemRepository(MediatorContext context) 
        : base(context)
    {
    }
}
