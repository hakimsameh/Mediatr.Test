namespace MediatrTest.Application.CQRS.Commands.ItemCommands.AddItem;

internal class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
    private readonly IItemModelRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public AddItemCommandHandler(IItemModelRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        unitOfWork.AddRepository(repository);
    }
    public async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var item = ItemModel.Create(request.ItemName, request.ItemDescription);
        await repository.AddOrUpdate(item);
        item.Submit(EditMode.Add);
        _ = await unitOfWork.CommitAsync(cancellationToken);
    }
}
