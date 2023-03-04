namespace MediatrTest.Common.Interfaces;

public interface IUnitOfWork
{
    void AddRepository<TEntity, TKey>(IRepository<TEntity, TKey> repository)
        where TEntity : IEntityBase<TKey>;
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);
}

