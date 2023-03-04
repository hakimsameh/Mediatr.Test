namespace MediatrTest.Infrastructure.Repositories
{
    internal class StoreDataRepository : RepositoryBase<StoreData, Guid>, IStoreDataRepository
    {
        public StoreDataRepository(MediatorContext context) 
            : base(context)
        {
            
        }

        public Task<StoreData> GetByItemIdAsync(Guid itemId)
            => DataSet.FirstOrDefaultAsync(x=>x.ItemId == itemId);
    }
}
