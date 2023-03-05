namespace MediatrTest.Domain.DomainEvents;

public class ItemDeletedEvent : IDomainEvent
{
    public ItemDeletedEvent(ItemModel deletedItem)
    {
        DeletedItem = deletedItem;
    }
    public ItemModel DeletedItem { get; }
}