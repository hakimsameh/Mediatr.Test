namespace MediatrTest.Common.Base;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
    where TKey : notnull
{
    public TKey Id {get; set; }
}

