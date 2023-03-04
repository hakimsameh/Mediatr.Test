namespace MediatrTest.Common.Interfaces;

public interface IRepository<T, TKey> where T : IEntityBase<TKey>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(TKey id);
    Task AddOrUpdate(T entity);
    //Task Update(T entity);
    Task Delete(TKey id);
}
