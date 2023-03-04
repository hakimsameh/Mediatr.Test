namespace MediatrTest.Application.CQRS.Commands;

public record UpdateItemCommand(Guid Id, string ItemName, string ItemDescription) : IRequest;

internal class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IItemModelRepository repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemCommandHandler(IItemModelRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this._unitOfWork = unitOfWork;
        this._unitOfWork.AddRepository(repository);
    }
    public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await repository.Get(request.Id);
        if (item != null)
        {
            item.UpdateData(request.ItemName, request.ItemDescription);
            await repository.AddOrUpdate(item);
            item.Submit(EditMode.Update);
            var result = await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}