namespace MediatrTest.Application.CQRS.Commands;

internal record AddLogCommand(DataLog Data) : IRequest;

internal class AddLogCommandHandler : IRequestHandler<AddLogCommand>
{
    private readonly IDataLogRepository repository;

    public AddLogCommandHandler(IDataLogRepository repository)
    {
        this.repository = repository;
    }
    public async Task Handle(AddLogCommand request, CancellationToken cancellationToken)
    {
        await repository.AddOrUpdate(request.Data);
    }
}
