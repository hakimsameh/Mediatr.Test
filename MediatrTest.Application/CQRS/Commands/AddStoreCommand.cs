namespace MediatrTest.Application.CQRS.Commands;

internal record AddOrUpdateStoreCommand(ItemModel ItemModel) : IRequest;

internal class AddStoreCommandHandler : IRequestHandler<AddOrUpdateStoreCommand>
{
    private readonly IStoreDataRepository repository;

    public AddStoreCommandHandler(IStoreDataRepository repository)
    {
        this.repository = repository;
    }
    public async Task Handle(AddOrUpdateStoreCommand request, CancellationToken cancellationToken)
    {
        StoreData data;
        var existing = await repository.GetByItemIdAsync(request.ItemModel.Id);
        if (existing != null)
        {
            existing.UpdateItem(request.ItemModel.Name);
            existing.AddQty();
            data = existing;
        }
        else
        {
            data = StoreData.Create(request.ItemModel.Id, request.ItemModel.Name);
        }
        await repository.AddOrUpdate(data);
    }
}
