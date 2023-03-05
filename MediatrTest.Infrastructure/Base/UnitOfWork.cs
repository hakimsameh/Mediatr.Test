namespace MediatrTest.Infrastructure.Base;
internal class UnitOfWork : IUnitOfWork , IDisposable
{
    private readonly Dictionary<string, object> _repositories = new();
    private readonly IMediator _mediator;

    public UnitOfWork(IMediator mediator)
    {
        _mediator = mediator;
    }

    private static DbContext GetContext(object repo)
    {
        var repository = repo as IEFRepository;
        return repository?.Context;
    }
    private List<DbContext> Contexts
    {
        get
        {
            var con = (from r in _repositories.ToArray()
                       group r by GetContext(r.Value) into grp
                       select grp.Key).ToList();
            con.RemoveAll(x => x == null);
            return con.ToList();
        }
    }
    public void AddRepository<TEntity, TKey>(IRepository<TEntity, TKey> repository) 
        where TEntity : IEntityBase<TKey>
    {
        var name = repository.GetType().ToString();
        if (!_repositories.ContainsKey(name))
            _repositories.Add(name, repository);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        var errorMessage = string.Empty;
        bool successfulCommitted = false;
        foreach (var db in Contexts)
        {
            await using var transaction =
                await db.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await PublishDomainEvents(db, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                successfulCommitted = true;                                
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                await transaction.RollbackAsync(cancellationToken);
                successfulCommitted = false;
            }
        }
        return successfulCommitted;
    }
    private async Task PublishDomainEvents(DbContext db, CancellationToken cancellationToken)
    {
        List<EntityEntry<IAggregateRoot>> aggregateRoots = db.ChangeTracker
                    .Entries<IAggregateRoot>()
                    .Where(entityEntry => entityEntry.Entity.DomainEvents.Any())
                    .ToList();
        List<IDomainEvent> domainEvents = aggregateRoots.SelectMany(
            entityEntry => entityEntry.Entity.DomainEvents).ToList();

        aggregateRoots.ForEach(
            entityEntry => entityEntry.Entity.ClearDomainEvents());

        IEnumerable<Task> tasks = domainEvents.Select(
            domainEvent => _mediator.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(tasks);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); 
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (Contexts != null && Contexts.Count() > 0)
            {
                Contexts.Clear();
            }
            _repositories.Clear();
        }
    }

}