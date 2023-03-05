namespace MediatrTest.Application.CQRS.Commands.AddOrUpdateStore;

internal class AddOrUpdateStoreHandler : IRequestHandler<AddOrUpdateStoreCommand>
{
    private readonly IStoreDataRepository repository;

    public AddOrUpdateStoreHandler(IStoreDataRepository repository)
        => this.repository = repository;

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
