namespace MediatrTest.Infrastructure.Base;
public abstract class RepositoryBase<T, TKey> 
    : IRepository<T, TKey>, IEFRepository 
    where T : EntityBase<TKey>
{
    public DbContext Context { get; }
    protected DbSet<T> DataSet => Context.Set<T>();
    protected RepositoryBase(DbContext context)
    {
        Context = context;
    }
    public async Task AddOrUpdate(T entity)
    {
        var existing = await DataSet.FirstOrDefaultAsync(
            x => x.Id.Equals(entity.Id));
        if (existing != null)
        {
            Context.Entry(existing).CurrentValues.SetValues(entity);
            Context.Entry(existing).State = EntityState.Modified;
        }
        else
        {
            await DataSet.AddAsync(entity);
        }
    }

    public async Task Delete(TKey id)
    {
        var entity = await DataSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (entity != null)
            DataSet.Remove(entity);
    }

    public async Task<T> Get(TKey id)
    {
        var entity = await DataSet
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        return entity ?? default;
    }

    public async Task<IEnumerable<T>> GetAll()
        => await DataSet.ToListAsync();
    
}
