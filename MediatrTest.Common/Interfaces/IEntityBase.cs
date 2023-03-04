namespace MediatrTest.Common.Interfaces;

public interface IEntityBase<TKey>
{
    public TKey Id { get; set; }
}
