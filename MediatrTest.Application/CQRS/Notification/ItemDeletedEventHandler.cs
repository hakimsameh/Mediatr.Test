namespace MediatrTest.Application.CQRS.Notification;

public class ItemDeletedEventHandler : INotificationHandler<ItemDeletedEvent>
{
    private readonly ISender sender;

    public ItemDeletedEventHandler(ISender sender)
    {
        this.sender = sender;
    }
    public async Task Handle(ItemDeletedEvent notification, CancellationToken cancellationToken)
    {
        var log = $"Item Deleted ID: {notification.DeletedItem.Id} - Name: {notification.DeletedItem.Name}";
        var logData = DataLog.Create(DateTime.Now, log, "Delete");
        await sender.Send(new AddLogCommand(logData), cancellationToken);
        await sender.Send(new DeleteStoreCommand(notification.DeletedItem), cancellationToken);
    }
}