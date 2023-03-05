namespace MediatrTest.Application.CQRS.Commands.ItemCommands.DeleteItem;


internal class DeleteItemHandler : IRequestHandler<DeleteItemCommand, bool>
{
    private readonly IItemModelRepository itemModelRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteItemHandler(IItemModelRepository itemModelRepository, IUnitOfWork unitOfWork)
    {
        this.itemModelRepository = itemModelRepository;
        this.unitOfWork = unitOfWork;
        this.unitOfWork.AddRepository(itemModelRepository);
    }
    public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemModelRepository.Get(request.Id);
        if (item == null)
        {
            return false;
        }
        item.UpdateData("Deleted", item.Description);
        //await itemModelRepository.Delete(request.Id);
        await itemModelRepository.Delete(item.Id);
        item.Deleted();
        await unitOfWork.CommitAsync(cancellationToken);
        return true;
    }
}