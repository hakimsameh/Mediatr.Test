namespace MediatrTest.Application.CQRS.Commands.AddOrUpdateStore;

internal class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand>
{
    private readonly IStoreDataRepository storeDataRepository;

    public DeleteStoreHandler(IStoreDataRepository storeDataRepository)
    {
        this.storeDataRepository = storeDataRepository;
    }
    public async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await storeDataRepository.GetByItemIdAsync(request.ItemModel.Id);
        store?.RemoveQty();
        await storeDataRepository.AddOrUpdate(store);
    }
}