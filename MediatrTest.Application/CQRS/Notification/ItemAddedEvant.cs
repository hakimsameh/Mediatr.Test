namespace MediatrTest.Application.CQRS.Notification;

internal class ItemAddedEventHandler : INotificationHandler<ItemSubmittedEvent>
{
    private readonly ISender sender;

    public ItemAddedEventHandler(ISender sender)
    {
        this.sender = sender;
    }
    public async Task Handle(ItemSubmittedEvent notification, CancellationToken cancellationToken)
    {
        var logTypeString = notification.EditMode == EditMode.Add ?
            "Item Added" : "Item Updated";
        var log = $"{logTypeString} ID: {notification.Item.Id} - Item Name {notification.Item.Name}";
        var logData = DataLog.Create(DateTime.Now, log, notification.EditMode.ToString());
        await sender.Send(new AddLogCommand(logData), cancellationToken);
        await sender.Send(new AddOrUpdateStoreCommand(notification.Item), cancellationToken);
    }
}
