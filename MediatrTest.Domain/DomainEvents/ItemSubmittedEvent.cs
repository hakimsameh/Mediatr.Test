namespace MediatrTest.Domain.DomainEvents;

public class ItemSubmittedEvent : IDomainEvent
{
    internal ItemSubmittedEvent(ItemModel item, EditMode editMode)
    {
        Item = item;
        EditMode = editMode;
    }
    public ItemModel Item { get; }
    public EditMode EditMode { get; }
}
