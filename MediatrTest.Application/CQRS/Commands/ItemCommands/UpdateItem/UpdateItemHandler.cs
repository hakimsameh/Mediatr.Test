namespace MediatrTest.Application.CQRS.Commands.ItemCommands.UpdateItem;

internal class UpdateItemHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IItemModelRepository repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemHandler(IItemModelRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        _unitOfWork = unitOfWork;
        _unitOfWork.AddRepository(repository);
    }
    public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await repository.Get(request.Id);
        if (item != null)
        {
            item.UpdateData(request.ItemName, request.ItemDescription);
            await repository.AddOrUpdate(item);
            item.Submit(EditMode.Update);
            _ = await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}