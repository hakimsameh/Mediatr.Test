namespace MediatrTest.Domain.Repositories;

public interface IStoreDataRepository : IRepository<StoreData, Guid>
{
    Task<StoreData> GetByItemIdAsync(Guid itemId);
}