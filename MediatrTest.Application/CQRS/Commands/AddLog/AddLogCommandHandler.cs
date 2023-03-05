using MediatrTest.Application.CQRS.Commands.AddLog;

namespace MediatrTest.Application.CQRS.Commands.AddOrUpdateLog;

internal class AddLogCommandHandler : IRequestHandler<AddLogCommand>
{
    private readonly IDataLogRepository repository;

    public AddLogCommandHandler(IDataLogRepository repository)
        => this.repository = repository;

    public async Task Handle(AddLogCommand request, CancellationToken cancellationToken)
        => await repository.AddOrUpdate(request.Data);
}
